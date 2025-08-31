import {Component, Input, OnInit} from '@angular/core';
import {ClientService} from '../../../services/ClientService';
import {ClientForm} from '../client-form/ClientForm';
import {Client} from '../../../models/Client';
  import {Guid} from '../../../models/Guid';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-client-update',
  standalone: false,
  templateUrl: './client-update.component.html',
  styleUrl: './client-update.component.css'
})
export class ClientUpdateComponent implements OnInit {
  clientId: Guid;
  public client!: Client

  constructor(
    private clientService: ClientService,
    private route: ActivatedRoute,
  ) {
    this.clientId = this.route.snapshot.paramMap.get('id')!;
  }

  onSubmit(form: ClientForm) {
    this.clientService.update(form)
      .subscribe({
        next: () => {
          alert("Пользаватель успешно обновлён xD")
        },
        error: err => {
          console.log(err)
          alert("Прозиошла ошибочка: go to => console")
        },
      });
  }

  public ngOnInit(): void {
    this.clientService.get(this.clientId).subscribe(client => {
      this.client = client;
    })
  }
}
