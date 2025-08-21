import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ClientFormComponent} from './client-form/client-form.component';
import {ClientRoutingModule} from './client-routing.module';
import { ClientTagsPickerComponent } from './client-tags-picker/client-tags-picker.component';
import { ClientPhoneInputComponent } from './client-phone-input/client-phone-input.component';
import { ClientPhoneListComponent } from './client-phone-list/client-phone-list.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ClientAddComponent } from './client-add/client-add.component';
import {NgxIntlTelInputModule} from "ngx-intl-tel-input";
import { ClientPasportComponent } from './client-pasport/client-pasport.component';

@NgModule({
  declarations: [
    ClientFormComponent,
    ClientTagsPickerComponent,
    ClientPhoneInputComponent,
    ClientPhoneListComponent,
    ClientAddComponent,
    ClientPasportComponent
  ],
    imports: [
        CommonModule,
        ClientRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        NgxIntlTelInputModule,
    ]
})
export class ClientModule {
}
