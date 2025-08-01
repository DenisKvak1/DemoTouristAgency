import {ClientTag} from '../../../models/ClientTag';
import {Guid} from '../../../models/Guid';

export class ClientTagForm {
  constructor(
    public id: Guid,
    public name: string,
    public selected: boolean = false
  ) {
  }
}
