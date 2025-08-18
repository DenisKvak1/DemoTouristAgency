import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {CountryISO, SearchCountryField} from 'ngx-intl-tel-input';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {

  protected readonly CountryISO = CountryISO;
  protected readonly SearchCountryField = SearchCountryField;
}
