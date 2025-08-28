import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {ClientTag} from '../../../models/ClientTag';
import {ClientTagForm} from '../client-tags-picker/ClientTagForm';
import {ClientTagService} from '../../../services/ClientTagService';
import {ClientPhoneForm, SocialMediaForm} from '../client-phone-input/ClientPhoneForm';
import {SocialMediaService} from '../../../services/SocialMediaService]';
import {Client} from '../../../models/Client';
import {AbstractControl, FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {ClientForm} from './ClientForm';
import {SocialMedia} from '../../../models/SocialMedia';
import {ClientPassportForm} from '../client-passport/ClientPassportForm';
import {ClientPassport, Sex} from '../../../models/ClientPassport';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {PhoneNumber} from '../client-phone-input/PhoneNumber';

@Component({
  selector: 'app-client-form',
  standalone: false,
  templateUrl: './client-form.component.html',
  styleUrl: './client-form.component.css'
})
export class ClientFormComponent implements OnInit {
  @Output() submitForm = new EventEmitter<ClientForm>();
  @Input() initialValue?: Client;
  withPassport: boolean = false;
  withPassportValidationFn = () => {
    return (control: AbstractControl) => {
      if (!this.withPassport) return null;
      return control.value == null || control.value === '' ? {required: true} : null;
    };
  };

  form = new FormGroup({
    firstName: new FormControl('', Validators.required,),
    lastName: new FormControl('', Validators.required),
    middleName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    allowNewSletter: new FormControl(false, Validators.required),
    phones: new FormArray<FormGroup<ClientPhoneForm>>([], Validators.required),
    passport: new FormGroup<ClientPassportForm>({
      id: new FormControl<string>('00000000-0000-0000-0000-000000000000', {
        nonNullable: true,
        validators: [this.withPassportValidationFn()]
      }),
      serialNumber: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      firstName: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      lastName: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      nationality: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      birthDate: new FormControl<Date>(new Date(), {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      gender: new FormControl<Sex | null>(null, [this.withPassportValidationFn()]),
      placeOfBirth: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      dateOfIssue: new FormControl<Date>(new Date(), {
        nonNullable: true,
        validators: [this.withPassportValidationFn()]
      }),
      dateOfExpiry: new FormControl<Date>(new Date(), {
        nonNullable: true,
        validators: [this.withPassportValidationFn()]
      }),
      record: new FormControl<string>('', {nonNullable: true, validators: [this.withPassportValidationFn()]}),
      authority: new FormControl<number>(0, {nonNullable: true, validators: [this.withPassportValidationFn()]}),
    }),
    tags: new FormArray<FormGroup<ClientTagForm>>([], Validators.required)
  });

  constructor(
    private clientTagService: ClientTagService,
    private socialMediaService: SocialMediaService,
    public modalService: NgbModal
  ) {

  }

  public isSocialMediasLoad = false;
  public socialMedias: ClientTag[] = []

  public ngOnInit(): void {
    this.setDefaultValue()
    this.clientTagService.getAll().subscribe((tags) => this.onTagLoad(tags))
    this.socialMediaService.getAll().subscribe((socialMedias) => this.onSocialMediaLoad(socialMedias))
  }

  private setDefaultValue() {
    if (!this.initialValue) return

    this.withPassport = Boolean(this.initialValue.passport)
    this.form.patchValue({
      firstName: this.initialValue.firstName,
      lastName: this.initialValue.lastName,
      middleName: this.initialValue.middleName,
      email: this.initialValue.email,
      allowNewSletter: this.initialValue.allowNewSletter,
      phones: this.initialValue.phones.map(phone => {
        return ClientPhoneForm.toPlain(new ClientPhoneForm(
          phone.id,
          {number: phone.number},
          phone.socialMedias.map(socialMedia => new SocialMediaForm(socialMedia.id, socialMedia.id))));
      })
    })
  }


  private onTagLoad(tags: ClientTag[]) {
    this.form.controls.tags.clear()
    tags.forEach(x => this.form.controls.tags.push(new FormGroup<ClientTagForm>(new ClientTagForm(x.id, x.name))))
  }

  private onSocialMediaLoad(socialMedias: SocialMedia[]) {
    this.socialMedias = socialMedias;
    this.isSocialMediasLoad = true;
  }

  public onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const formResult = this.form.value;
    this.submitForm.emit(new ClientForm(
      formResult.firstName as string,
      formResult.lastName as string,
      formResult.middleName as string,
      formResult.email as string,
      formResult.allowNewSletter as boolean,
      this.withPassport ? formResult.passport as ClientPassport : null,
      (formResult.phones ?? []).map((phone) => {
        return {
          id: phone.id as string,
          number: (phone.number as PhoneNumber).number,
          socialMedias: (phone.socialMedias ?? []).filter(x => x.selected).map(x => x.id as string)
        }
      }),
      (formResult.tags ?? []).filter(x => x.selected).map(x => x.id as string)
    ))
    if (!this.initialValue) this.resetForm()
  }

  private resetForm() {
    this.form.reset({
      firstName: '',
      lastName: '',
      middleName: '',
      email: '',
      allowNewSletter: false,
      phones: [],
      tags: (this.form.controls.tags.value ?? []).map(x =>
        ClientTagForm.toPlain(new ClientTagForm(x.id as string, x.name as string))
      )
    });
  }

  public onPassportChangeState() {
    Object.values(this.form.controls.passport.controls).forEach(control => {
      control.updateValueAndValidity();
    });
  }
}
