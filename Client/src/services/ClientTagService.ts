import {environment} from '../../env';
import {HttpClient} from '@angular/common/http';
import {Client} from '../models/Client';
import {Observable} from 'rxjs';
import {ClientTag} from '../models/ClientTag';
import {Injectable} from '@angular/core';

@Injectable({providedIn: 'root'})
export class ClientTagService {
  private baseUrl = environment.BASE_URL + 'clientTag';

  constructor(
    private readonly client: HttpClient,
  ) {
  }

  public getAll(): Observable<ClientTag[]> {
    return this.client.get<ClientTag[]>(this.baseUrl)
  }
}
