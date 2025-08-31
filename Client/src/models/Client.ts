import {ClientPhone} from './ClientPhone';
import {ClientTag} from './ClientTag';
import {ClientPassport} from './ClientPassport';
import {Guid} from './Guid';

export class Client {
  constructor(
    public id: Guid,
    public firstName: string,
    public lastName: string,
    public middleName: string,
    public email: string,
    public allowNewSletter: boolean,
    public passport: ClientPassport | null,
    public phones: ClientPhone[],
    public tags: ClientTag[]
  ) {
  }
}
