import {Component, forwardRef, Input} from '@angular/core';
import {ClientTagForm} from './ClientTagForm';
import {FormArray, FormGroup, NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
  selector: 'app-client-tags-picker',
  standalone: false,
  templateUrl: './client-tags-picker.component.html',
  styleUrl: './client-tags-picker.component.css'
})
export class ClientTagsPickerComponent {
  @Input() tags!: FormArray<FormGroup<ClientTagForm>>;
  constructor() {

  }

  trackById(i: number, tag: FormGroup<ClientTagForm>) {
    return tag.value.id;
  }
}
