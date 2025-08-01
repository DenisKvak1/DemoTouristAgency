import {Component} from '@angular/core';
import {ClientForm} from '../client-form/ClientForm';
import {ClientService} from '../../../services/ClientService';

@Component({
  selector: 'app-client-add',
  standalone: false,
  templateUrl: './client-add.component.html',
  styleUrl: './client-add.component.css'
})
export class ClientAddComponent {
  constructor(
    private clientService: ClientService,
  ) {
  }

  onSubmit(form: ClientForm) {
    this.clientService.add(form)
      .subscribe({
        next: () => {
          alert("Пользаватель успешно добавлен xD")
        },
        error: err => {
          console.log(err)
          alert("Прозиошла ошибочка: go to => console")
        },
      });
  }
}
