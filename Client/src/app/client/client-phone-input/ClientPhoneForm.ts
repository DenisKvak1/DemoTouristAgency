import {Guid} from '../../../models/Guid';
import {FormArray, FormControl, FormGroup} from '@angular/forms';

export class ClientPhoneForm {
  public id: FormControl<Guid>;
  public number: FormControl<string>;
  public socialMedias: FormArray<FormGroup<SocialMediaForm>>;

  constructor(
    id: Guid,
    number: string,
    socialMedias: SocialMediaForm[] = []
  ) {
    this.id = new FormControl<Guid>(id, {nonNullable: true});
    this.number = new FormControl<string>(number, {nonNullable: true});

    this.socialMedias = new FormArray(
      socialMedias.map(sm => new FormGroup<SocialMediaForm>({
        id: sm.id,
        name: sm.name,
        selected: sm.selected
      }))
    );
  }

  public static toPlain(form: ClientPhoneForm) {
    return {
      id: form.id.value,
      number: form.number.value,
      socialMedias: form.socialMedias.value,
    }
  }
}

export class SocialMediaForm {
  public id: FormControl<Guid>
  public name: FormControl<string>
  public selected = new FormControl<boolean>(false, {nonNullable: true})

  constructor(
    id: Guid,
    name: string,
    selected: boolean = false
  ) {
    this.id = new FormControl(id, {nonNullable: true});
    this.name = new FormControl(name, {nonNullable: true});
    this.selected = new FormControl<boolean>(selected, {nonNullable: true});
  }
}
