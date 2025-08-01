import {ClientPhone} from '../../../models/ClientPhone';
import {ClientTag} from '../../../models/ClientTag';
import {Guid} from '../../../models/Guid';
import {SocialMedia} from '../../../models/SocialMedia';

interface ClientPhoneForm {
  id: Guid,
  number: string,
  socialMedias: Guid[]
}

export class ClientForm {
  constructor(
    public firstName: string,
    public lastName: string,
    public middleName: string,
    public email: string,
    public allowNewSletter: boolean,
    public phones: ClientPhoneForm[],
    public tags: Guid[]
  ) {
  }
}
