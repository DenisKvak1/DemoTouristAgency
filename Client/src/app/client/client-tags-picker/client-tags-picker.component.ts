import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Guid} from '../../../models/Guid';
import {ClientTag} from '../../../models/ClientTag';
import {ClientTagForm} from './ClientTagForm';

@Component({
  selector: 'app-client-tags-picker',
  standalone: false,
  templateUrl: './client-tags-picker.component.html',
  styleUrl: './client-tags-picker.component.css'
})
export class ClientTagsPickerComponent {
  @Input() tags!: ClientTagForm[];
  @Output() tagsChange = new EventEmitter<ClientTagForm[]>();

  trackById(i: number, tag: ClientTagForm) {
    return tag.id;
  }
}
