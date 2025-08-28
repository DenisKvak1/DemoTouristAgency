import {Guid} from './Guid';
import {SocialMedia} from './SocialMedia';

export enum Sex {
  MALE = "MALE",
  FEMALE = "FEMALE",
}

export class ClientPassport {
  constructor(
    public id: Guid,
    public serialNumber: string,
    public firstName: string,
    public lastName: string,
    public nationality: string,
    public birthDate: Date,
    public gender: Sex,
    public placeOfBirth: string,
    public dateOfIssue: Date,
    public dateOfExpiry: Date,
    public record: string,
    public authority: number,
  ) {
  }
}
