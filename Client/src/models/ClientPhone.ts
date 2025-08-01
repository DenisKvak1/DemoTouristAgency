import {Guid} from './Guid';
import {SocialMedia} from './SocialMedia';

export class ClientPhone {
  constructor(
    public id: Guid,
    public number: string,
    public socialMedias: SocialMedia[]
  ) {
  }
}
