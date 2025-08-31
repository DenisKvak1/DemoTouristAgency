import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {ClientFormComponent} from './client-form/client-form.component';
import {ClientAddComponent} from './client-add/client-add.component';
import {ClientUpdateComponent} from './client-update/client-update.component';

const routes: Routes = [
  {path: 'add', component: ClientAddComponent},
  {path: 'update/:id', component: ClientUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ClientRoutingModule {
}
