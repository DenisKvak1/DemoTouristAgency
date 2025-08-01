import {Component, EventEmitter, HostBinding, Input, Output} from '@angular/core';
import {ClientPhoneForm, SocialMediaForm} from '../client-phone-input/ClientPhoneForm';
import {SocialMedia} from '../../../models/SocialMedia';

@Component({
  selector: 'app-client-phone-list',
  standalone: false,
  templateUrl: './client-phone-list.component.html',
  styleUrl: './client-phone-list.component.css'
})
export class ClientPhoneListComponent {
  @Input() phones!: ClientPhoneForm[];
  @Output() phonesChange = new EventEmitter<ClientPhoneForm[]>();
  @Input() socialMedias!: SocialMedia[]
  @Output() addPhone = new EventEmitter();

  onPhoneDelete(index: number) {
    this.phones.splice(index, 1)
  }

  trackById(i: number, tag: ClientPhoneForm) {
    return tag.id;
  }
}
