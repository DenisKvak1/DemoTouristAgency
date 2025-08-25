import {ClientTag} from '../../../models/ClientTag';
import {Guid} from '../../../models/Guid';
import {FormControl} from '@angular/forms';

export class ClientTagForm {
  public id: FormControl<Guid>;
  public name: FormControl<string>;
  public selected: FormControl<boolean>;

  constructor(
    id: Guid,
    name: string,
    selected: boolean = false
  ) {
    this.id = new FormControl<Guid>(id, { nonNullable: true });
    this.name = new FormControl<string>(name, { nonNullable: true });
    this.selected = new FormControl<boolean>(selected, { nonNullable: true });
  }

  public static toPlain(form: ClientTagForm) {
    return {
      id: form.id.value,
      name: form.name.value,
      selected: form.selected.value
    };
  }
}
