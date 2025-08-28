import {ClientPhone} from './ClientPhone';
import {ClientTag} from './ClientTag';
import {ClientPassport} from './ClientPassport';

export class Client {
  constructor(
    public firstName: string,
    public lastName: string,
    public middleName: string,
    public email: string,
    public allowNewSletter: boolean,
    public passport: ClientPassport,
    public phones: ClientPhone[],
    public tags: ClientTag[]
  ) {
  }
}
