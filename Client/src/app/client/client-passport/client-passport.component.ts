import {Component, Input} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {ClientPassportForm} from './ClientPassportForm';
import {Sex} from '../../../models/ClientPassport';

@Component({
  selector: 'app-client-passport',
  standalone: false,
  templateUrl: './client-passport.component.html',
  styleUrl: './client-passport.component.css'
})
export class ClientPassportComponent {
  @Input() passport!: FormGroup<ClientPassportForm>;

  protected readonly Sex = Sex;
}
