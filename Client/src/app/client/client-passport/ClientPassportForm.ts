import {Guid} from '../../../models/Guid';
import {Sex} from '../../../models/ClientPassport';
import {FormControl} from '@angular/forms';

export class ClientPassportForm {
  public id: FormControl<Guid>;
  public serialNumber: FormControl<string>;
  public firstName: FormControl<string>;
  public lastName: FormControl<string>;
  public nationality: FormControl<string>;
  public birthDate: FormControl<Date>;
  public gender: FormControl<Sex | null>;
  public placeOfBirth: FormControl<string>;
  public dateOfIssue: FormControl<Date>;
  public dateOfExpiry: FormControl<Date>;
  public record: FormControl<string>;
  public authority: FormControl<number>;

  constructor(
    id: string,
    serialNumber: string,
    firstName: string,
    lastName: string,
    nationality: string,
    birthDate: Date,
    gender: Sex,
    placeOfBirth: string,
    dateOfIssue: Date,
    dateOfExpiry: Date,
    record: string,
    authority: number
  ) {
    this.id = new FormControl<string>(id, {nonNullable: true});
    this.serialNumber = new FormControl<string>(serialNumber, {nonNullable: true});
    this.firstName = new FormControl<string>(firstName, {nonNullable: true});
    this.lastName = new FormControl<string>(lastName, {nonNullable: true});
    this.nationality = new FormControl<string>(nationality, {nonNullable: true});
    this.birthDate = new FormControl<Date>(birthDate, {nonNullable: true});
    this.gender = new FormControl<Sex>(gender);
    this.placeOfBirth = new FormControl<string>(placeOfBirth, {nonNullable: true});
    this.dateOfIssue = new FormControl<Date>(dateOfIssue, {nonNullable: true});
    this.dateOfExpiry = new FormControl<Date>(dateOfExpiry, {nonNullable: true});
    this.record = new FormControl<string>(record, {nonNullable: true});
    this.authority = new FormControl<number>(authority, {nonNullable: true});
  }

  public static toPlain(form: ClientPassportForm) {
    return {
      id: form.id.value,
      serialNumber: form.serialNumber.value,
      firstName: form.firstName.value,
      lastName: form.lastName.value,
      nationality: form.nationality.value,
      birthDate: form.birthDate.value,
      gender: form.gender.value,
      placeOfBirth: form.placeOfBirth.value,
      dateOfIssue: form.dateOfIssue.value,
      dateOfExpiry: form.dateOfExpiry.value,
      record: form.record.value,
      authority: form.authority.value,
    };
  }
}

