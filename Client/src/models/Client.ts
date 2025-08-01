import {ClientPhone} from './ClientPhone';
import {ClientTag} from './ClientTag';

export class Client {
  constructor(
    public firstName: string,
    public lastName: string,
    public middleName: string,
    public email: string,
    public allowNewSletter: boolean,
    public phones: ClientPhone[],
    public tags: ClientTag[]
  ) {
  }
}
