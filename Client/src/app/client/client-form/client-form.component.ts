import {AfterViewInit, Component, EventEmitter, Inject, Input, OnInit, Output, ViewChild} from '@angular/core';
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
import {ClientPhoneListComponent} from '../client-phone-list/client-phone-list.component';

@Component({
  selector: 'app-client-form',
  standalone: false,
  templateUrl: './client-form.component.html',
  styleUrl: './client-form.component.css'
})
export class ClientFormComponent implements OnInit {
  @ViewChild(ClientPhoneListComponent, {static: false}) phoneListComponent!: ClientPhoneListComponent;

  @Output() submitForm = new EventEmitter<ClientForm>();
  @Input() initialValue?: Client;
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    middleName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    allowNewSletter: new FormControl(false, Validators.required),
    phones: new FormControl<ClientPhoneForm[]>([], Validators.required),
    tags: new FormControl<ClientTagForm[]>([], Validators.required)
  });

  constructor(
    private clientTagService: ClientTagService,
    private socialMediaService: SocialMediaService
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

    this.form.patchValue({
      firstName: this.initialValue.firstName,
      lastName: this.initialValue.lastName,
      middleName: this.initialValue.middleName,
      email: this.initialValue.email,
      allowNewSletter: this.initialValue.allowNewSletter,
      phones: this.initialValue.phones.map(phone => {
        return new ClientPhoneForm(phone.id, phone.number, phone.socialMedias.map(socialMedia => new SocialMediaForm(socialMedia.id, socialMedia.id)));
      })
    })
  }


  private onTagLoad(tags: ClientTag[]) {
    if (!this.initialValue) {
      this.form.controls.tags.patchValue(tags.map(x => new ClientTagForm(x.id, x.name)))
    } else {
      this.form.controls.tags.patchValue(
        this.initialValue.tags
          .filter(x => !tags.some(tag => x.id === tag.id))
          .map(tag => {
            const tags = this.form.controls.tags.value as ClientTagForm[]
            const foundTag = tags.find(x => x.id === tag.id)
            return {
              ...foundTag,
              selected: true
            } as ClientTagForm
          }));
    }
  }

  private onSocialMediaLoad(socialMedias: SocialMedia[]) {
    this.socialMedias = socialMedias;
    this.isSocialMediasLoad = true;
  }

  public onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.phoneListComponent.markAsTouched()
      console.log('invalid')
      return;
    }
    const formResult = this.form.value;
    this.submitForm.emit(new ClientForm(
      formResult.firstName as string,
      formResult.lastName as string,
      formResult.middleName as string,
      formResult.email as string,
      formResult.allowNewSletter as boolean,
      (formResult.phones as ClientPhoneForm[]).map((phone) => {
        return {
          id: phone.id,
          number: phone.number,
          socialMedias: phone.socialMedias.filter(x => x.selected).map(x => x.id)
        }
      }),
      (formResult.tags as ClientTagForm[]).filter(x => x.selected).map(x => x.id)
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
      tags: (this.form.controls.tags.value as ClientTagForm[]).map(x => new ClientTagForm(x.id, x.name))
    });
  }
}
