import {Component, forwardRef, Input} from '@angular/core';
import {ClientPhoneForm, SocialMediaForm} from '../client-phone-input/ClientPhoneForm';
import {SocialMedia} from '../../../models/SocialMedia';
import {
  AbstractControl,
  ControlValueAccessor,
  FormArray,
  FormControl, NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  ValidationErrors,
  Validator
} from '@angular/forms';

@Component({
  selector: 'app-client-phone-list',
  standalone: false,
  templateUrl: './client-phone-list.component.html',
  styleUrl: './client-phone-list.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ClientPhoneListComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => ClientPhoneListComponent),
      multi: true
    }
  ]
})
export class ClientPhoneListComponent implements ControlValueAccessor, Validator {
  phones = new FormArray<FormControl<ClientPhoneForm>>([]);
  @Input() socialMedias!: SocialMedia[]

  private validateEmit!: () => void;
  private changeEmit!: (phones: ClientPhoneForm[]) => void;
  private touchEmit!: () => void;

  constructor() {
    this.phones.valueChanges.subscribe(val => {
      this.changeEmit(val);
      this.validateEmit()
    });
  }

  public writeValue(phones: ClientPhoneForm[]): void {
    if (!phones) {
      this.phones.clear();
      return;
    }
    if (phones.length === 0 && this.changeEmit !== undefined) {
      this.addPhone()
    }
    if (phones.length === this.phones.length) {
      return this.phones.setValue(phones, {emitEvent: false});
    }

    this.phones.clear({emitEvent: false});
    phones.forEach(p => {
      this.phones.push(new FormControl<ClientPhoneForm>(p, {
        nonNullable: true,
      }));
    });
  }

  public markAsTouched() {
    this.phones.markAllAsTouched()
  }

  public addPhone() {
    if (this.phones.length !== 0 && this.phones.value.some(x => x.number === '')) {
      return this.phones.markAllAsTouched()
    }
    this.phones.push(
      new FormControl<ClientPhoneForm>(this.getEmptyPhone(), {nonNullable: true})
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

  public registerOnChange(fn: (phones: ClientPhoneForm[]) => void): void {
    this.changeEmit = fn;
    if (this.phones.length === 0) this.addPhone()
  }

  public registerOnTouched(fn: () => void): void {
    this.touchEmit = fn;
  }

  public trackById(i: number, tag: FormControl<ClientPhoneForm>) {
    return tag.value.id;
  }

  public validate(control: AbstractControl): ValidationErrors | null {
    const errors: ValidationErrors = {}
    this.phones.controls.forEach((control, index) => {
      if (control.errors) errors[`phone_${index}`] = true;
    })
    return errors
  }

  public registerOnValidatorChange(fn: () => void): void {
    this.validateEmit = fn;
  }
}
