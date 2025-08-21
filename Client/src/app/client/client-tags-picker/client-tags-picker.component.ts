import {Component, EventEmitter, forwardRef, Input, Output} from '@angular/core';
import {Guid} from '../../../models/Guid';
import {ClientTag} from '../../../models/ClientTag';
import {ClientTagForm} from './ClientTagForm';
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import {ClientPhoneForm} from '../client-phone-input/ClientPhoneForm';

@Component({
  selector: 'app-client-tags-picker',
  standalone: false,
  templateUrl: './client-tags-picker.component.html',
  styleUrl: './client-tags-picker.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ClientTagsPickerComponent),
      multi: true
    },
  ]
})
export class ClientTagsPickerComponent implements ControlValueAccessor {
  tags!: ClientTagForm[];

  private onChange!: (phone: ClientTagForm[]) => void;

  trackById(i: number, tag: ClientTagForm) {
    return tag.id;
  }

  public registerOnChange(fn: (value: ClientTagForm[]) => void): void {
    this.onChange = fn;
  }

  public registerOnTouched(fn: () => void): void {
  }

  public writeValue(tags: ClientTagForm[]): void {
    this.tags = tags;
  }

  public onCheck() {
    this.onChange(this.tags)
  }
}
