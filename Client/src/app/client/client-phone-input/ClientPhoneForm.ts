import {Guid} from '../../../models/Guid';

export class ClientPhoneForm {
  constructor(
    public id: Guid,
    public number: string,
    public socialMedias: SocialMediaForm[]
  ) {
  }
}

export class SocialMediaForm {
  constructor(
    public id: Guid,
    public name: string,
    public selected: boolean = false
  ) {
  }
}
