import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {ClientTag} from '../../../models/ClientTag';
import {ClientTagForm} from '../client-tags-picker/ClientTagForm';
import {ClientTagService} from '../../../services/ClientTagService';
import {ClientPhoneForm, SocialMediaForm} from '../client-phone-input/ClientPhoneForm';
import {SocialMediaService} from '../../../services/SocialMediaService]';
import {Client} from '../../../models/Client';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {ClientForm} from './ClientForm';
import {ClientPhone} from '../../../models/ClientPhone';
import {SocialMedia} from '../../../models/SocialMedia';

@Component({
  selector: 'app-client-form',
  standalone: false,
  templateUrl: './client-form.component.html',
  styleUrl: './client-form.component.css'
})
export class ClientFormComponent implements OnInit {
  @Output() submitForm = new EventEmitter<ClientForm>();

  @Input() initialValue?: Client;
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    middleName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    allowNewSletter: new FormControl(false, Validators.required),
  });

  constructor(
    private clientTagService: ClientTagService,
    private socialMediaService: SocialMediaService
  ) {
  }

  public tags: ClientTagForm[] = []
  public socialMedias: ClientTag[] = []
  public phones: ClientPhoneForm[] = []

  public ngOnInit(): void {
    this.setDefaultValue()
    this.clientTagService.getAll().subscribe((tags) => this.onTagLoad(tags))
    this.socialMediaService.getAll().subscribe((socialMedias) => this.onSocialMediaLoad(socialMedias))
  }

  private onTagLoad(tags: ClientTag[]) {
    this.tags = tags.map(x => new ClientTagForm(x.id, x.name));
    if (this.initialValue) {
      this.initialValue.tags.forEach(tag => {
        const foundTag = this.tags.find(x => x.id === tag.id)
        if (!foundTag) return
        foundTag.selected = true;
      });
    }
  }

  private onSocialMediaLoad(socialMedias: SocialMedia[]) {
    this.socialMedias = socialMedias;
    if (!this.initialValue || this.initialValue?.phones.length === 0) {
      this.phones.push(this.getEmptyPhone())
    }
  }

  public addPhone() {
    this.phones.push(this.getEmptyPhone())
  }

  private getEmptyPhone() {
    return new ClientPhoneForm(
      '00000000-0000-0000-0000-000000000000',
      "",
      this.socialMedias.map((x) => new SocialMediaForm(x.id, x.name))
    )
  }

  private setDefaultValue() {
    if (!this.initialValue) return

    this.form.patchValue({
      firstName: this.initialValue.firstName,
      lastName: this.initialValue.lastName,
      middleName: this.initialValue.middleName,
      email: this.initialValue.email,
      allowNewSletter: this.initialValue.allowNewSletter,
    })
    this.phones = this.initialValue.phones.map(phone => {
      return new ClientPhoneForm(phone.id, phone.number, phone.socialMedias.map(socialMedia => new SocialMediaForm(socialMedia.id, socialMedia.id)));
    });
  }

  public onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      console.log('invalid')
      return;
    }
    if (this.phones.some(phone => phone.number == '')) {
      console.log('invaliddd')
      return;
    }
    const formResult = this.form.value;
    this.submitForm.emit(new ClientForm(
      formResult.firstName as string,
      formResult.lastName as string,
      formResult.middleName as string,
      formResult.email as string,
      formResult.allowNewSletter as boolean,
      this.phones.map((phone) => {
        return {
          id: phone.id,
          number: phone.number,
          socialMedias: phone.socialMedias.filter(x => x.selected).map(x => x.id)
        }
      }),
      this.tags.filter(x => x.selected).map(x => x.id)
    ))
    if (!this.initialValue) this.resetForm()
  }

  private resetForm() {
    this.form.reset({
      firstName: '',
      lastName: '',
      middleName: '',
      email: '',
      allowNewSletter: false
    });
    this.phones = [this.getEmptyPhone()]
    this.tags.forEach(x => x.selected = false)
  }
}
