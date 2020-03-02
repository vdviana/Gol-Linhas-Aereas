import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TravelsComponent } from './travels/travels.component';
import { TravelDetailComponent } from './travel-detail/travel-detail.component';
import { LoginComponent } from './login/login.component';
import { AddTravelComponent } from './add-travel/add-travel.component';

const routes: Routes = [

  {
    path: 'travels',
    component: TravelsComponent,
    data: { title: 'Lista de Viagens' }
  },
  {
    path: 'travel-detail/:id',
    component: TravelDetailComponent,
    data: { title: 'Detalhes da Viagem' }
  },
  {
    path: 'add-travel/:id',
    component: AddTravelComponent,
    data: { title: 'Adicionar/Editar Viagem' }
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: LoginComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
