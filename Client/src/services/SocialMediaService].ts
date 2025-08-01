import {Injectable} from '@angular/core';
import {environment} from '../../env';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ClientTag} from '../models/ClientTag';
import {SocialMedia} from '../models/SocialMedia';

@Injectable({providedIn: 'root'})
export class SocialMediaService {
  private baseUrl = environment.BASE_URL + 'socialMedia';

  constructor(
    private readonly client: HttpClient,
  ) {
  }

  public getAll(): Observable<SocialMedia[]> {
    return this.client.get<SocialMedia[]>(this.baseUrl)
  }
}
