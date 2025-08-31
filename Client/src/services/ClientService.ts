import {HttpClient} from '@angular/common/http';
import {environment} from '../../env';
import {Client} from '../models/Client';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {ClientForm} from '../app/client/client-form/ClientForm';
import {Guid} from '../models/Guid';

@Injectable({providedIn: 'root'})
export class ClientService {
  private baseUrl = environment.BASE_URL + 'client';

  constructor(
    private readonly client: HttpClient,
  ) {
  }


  public add(client: ClientForm): Observable<null> {
    return this.client.post<null>(this.baseUrl, client)
  }

  public update(client: ClientForm): Observable<Client> {
    return this.client.patch<Client>(this.baseUrl, client)
  }

  public get(id: Guid): Observable<Client> {
    return this.client.get<Client>(`${this.baseUrl}/${id}`)
  }
}
