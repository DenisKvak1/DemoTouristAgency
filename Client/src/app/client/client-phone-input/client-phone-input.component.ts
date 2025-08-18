import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ClientTagForm} from '../client-tags-picker/ClientTagForm';
import {ClientPhoneForm, SocialMediaForm} from './ClientPhoneForm';
import {CountryISO, SearchCountryField} from 'ngx-intl-tel-input';

@Component({
  selector: 'app-client-phone-input',
  standalone: false,
  templateUrl: './client-phone-input.component.html',
  styleUrl: './client-phone-input.component.css'
})
export class ClientPhoneInputComponent {
  @Input() phone!: ClientPhoneForm;
  @Output() phoneChange = new EventEmitter<ClientPhoneForm>();

  @Input() isDeletable: boolean = true;
  @Output() delete = new EventEmitter();

  trackById(i: number, tag: SocialMediaForm) {
    return tag.id;
  }

  protected readonly CountryISO = CountryISO;
  protected readonly SearchCountryField = SearchCountryField;
}
