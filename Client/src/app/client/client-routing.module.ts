import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {ClientFormComponent} from './client-form/client-form.component';
import {ClientAddComponent} from './client-add/client-add.component';

const routes: Routes = [
  {path: 'add', component: ClientAddComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ClientRoutingModule {
}
