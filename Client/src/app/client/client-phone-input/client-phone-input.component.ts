import {
  AfterViewInit,
  Component,
  EventEmitter,
  forwardRef,
  Injector,
  Input, OnInit,
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
  FormControl, FormGroup,
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
})
export class ClientPhoneInputComponent implements AfterViewInit, OnInit {
  @ViewChild(NgxIntlTelInputComponent, {static: true}) phoneInput!: NgxIntlTelInputComponent;

  protected readonly CountryISO = CountryISO;
  protected readonly SearchCountryField = SearchCountryField;
  @Input() phoneControl!: FormGroup<ClientPhoneForm>
  @Input() isDeletable: boolean = true;
  @Output() delete = new EventEmitter();

  constructor() {

  }

  trackById(i: number, tag: FormGroup<SocialMediaForm>) {
    return tag.value.id;
  }

  ngAfterViewInit() {
    this.phoneInput.onTouched = () => {
      this.phoneControl.markAsTouched()
    };
  }

  public ngOnInit(): void {
    this.phoneControl.controls.number.setValidators(Validators.required)
  }
}
