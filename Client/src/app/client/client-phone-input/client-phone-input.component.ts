import {
  AfterViewInit,
  Component,
  EventEmitter,
  forwardRef,
  Injector,
  Input,
  Optional,
  Output,
  Self,
  ViewChild
} from '@angular/core';
import {ClientPhoneForm, SocialMediaForm} from './ClientPhoneForm';
import {CountryISO, NgxIntlTelInputComponent, SearchCountryField} from 'ngx-intl-tel-input';
import {
  AbstractControl,
  ControlValueAccessor,
  FormControl,
  NG_VALIDATORS,
  NG_VALUE_ACCESSOR,
  NgControl, ValidationErrors, Validator,
  Validators
} from '@angular/forms';
import {Guid} from '../../../models/Guid';
import {distinctUntilChanged} from 'rxjs';
import {observableToBeFn} from 'rxjs/internal/testing/TestScheduler';

export interface PhoneNumber {
  number: string;       // полный номер с кодом страны
  internationalNumber: string;
  nationalNumber: string;
  e164Number: string;   // формат +380XXXXXXXXX
  countryCode: string;  // 'UA', 'US' и т.д.
  dialCode: string;     // '+380'
}

@Component({
  selector: 'app-client-phone-input',
  standalone: false,
  templateUrl: './client-phone-input.component.html',
  styleUrl: './client-phone-input.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ClientPhoneInputComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => ClientPhoneInputComponent),
      multi: true
    }
  ]
})
export class ClientPhoneInputComponent implements ControlValueAccessor, Validator, AfterViewInit {
  @ViewChild(NgxIntlTelInputComponent, {static: true}) phoneInput!: NgxIntlTelInputComponent;

  protected readonly CountryISO = CountryISO;
  protected readonly SearchCountryField = SearchCountryField;
  public phoneNumberControl = new FormControl<PhoneNumber>({
    number: '',
    internationalNumber: '',
    nationalNumber: '',
    e164Number: '',
    countryCode: '',
    dialCode: ''
  }, [Validators.required]);
  public id: Guid = '00000000-0000-0000-0000-000000000000'
  public socialMedias: SocialMediaForm[] = []

  @Input() isDeletable: boolean = true;
  @Output() delete = new EventEmitter();

  private emitChange!: (phone: ClientPhoneForm) => void;
  private emitTouched!: () => void;
  private emitValidate!: () => void;

  constructor() {
  }

  trackById(i: number, tag: SocialMediaForm) {
    return tag.id;
  }

  public registerOnChange(fn: (phone: ClientPhoneForm) => void): void {
    this.emitChange = fn;
  }

  public registerOnTouched(fn: () => void): void {
    this.emitTouched = fn;
  }

  public writeValue(phone: ClientPhoneForm): void {
    this.id = phone.id;
    this.socialMedias = phone.socialMedias;
    this.phoneNumberControl.patchValue({
      number: phone.number,
      internationalNumber: '',
      nationalNumber: '',
      e164Number: '',
      countryCode: '',
      dialCode: ''
    });
  }

  public onPhoneInput() {
    this.emitChange(this.form)
  }

  public onSocialMediaUpdate() {
    this.emitChange(this.form)
  }

  ngAfterViewInit() {
    this.phoneInput.onTouched = () => {
      this.emitTouched()
      this.emitValidate()
    };
  }

  public registerOnValidatorChange(fn: () => void): void {
    this.emitValidate = fn;
  }

  get form() {
    return new ClientPhoneForm(this.id, this.phoneNumberControl.value?.number as string, this.socialMedias);
  }

  public validate(control: AbstractControl): ValidationErrors | null {
    if (this.phoneNumberControl.valid && Boolean(this.phoneNumberControl.value?.number)) return null
    return {
      ...this.phoneNumberControl.errors,
      required: !Boolean(this.phoneNumberControl.value?.number)
    };
  }
}
