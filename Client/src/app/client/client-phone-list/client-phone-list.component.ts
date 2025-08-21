import {Component, forwardRef, Input, OnInit} from '@angular/core';
import {ClientPhoneForm, SocialMediaForm} from '../client-phone-input/ClientPhoneForm';
import {SocialMedia} from '../../../models/SocialMedia';
import {
  AbstractControl,
  ControlValueAccessor,
  FormArray,
  FormControl, FormGroup, NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  ValidationErrors,
  Validator, Validators
} from '@angular/forms';

@Component({
  selector: 'app-client-phone-list',
  standalone: false,
  templateUrl: './client-phone-list.component.html',
  styleUrl: './client-phone-list.component.css'
})
export class ClientPhoneListComponent implements OnInit {
  @Input() phones!: FormArray<FormGroup<ClientPhoneForm>>;
  @Input() socialMedias!: SocialMedia[]

  public addPhone() {
    if (this.phones.length !== 0 && this.phones.controls.some(x => x.controls.number.invalid)) {
      return this.phones.markAllAsTouched()
    }
    this.phones.push(
      new FormGroup<ClientPhoneForm>(this.getEmptyPhone())
    );
  }

  public deletePhone(index: number) {
    this.phones.removeAt(index)
  }

  private getEmptyPhone() {
    return new ClientPhoneForm(
      '00000000-0000-0000-0000-000000000000',
      "",
      this.socialMedias?.map((x) => new SocialMediaForm(x.id, x.name))
    )
  }

  public ngOnInit(): void {
    if (this.phones.length === 0) this.addPhone()
  }

  public trackById(i: number, tag: FormGroup<ClientPhoneForm>) {
    return tag.value.id;
  }
}
