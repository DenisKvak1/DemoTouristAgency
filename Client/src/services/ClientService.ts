import {HttpClient} from '@angular/common/http';
import {environment} from '../../env';
import {Client} from '../models/Client';
import {Observable} from 'rxjs';
import {Injectable} from '@angular/core';
import {ClientForm} from '../app/client/client-form/ClientForm';

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
}
