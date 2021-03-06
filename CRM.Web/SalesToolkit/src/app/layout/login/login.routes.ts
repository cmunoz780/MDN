import { NgModule }             from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login.component';
import { DoLoginComponent } from './dologin.component';

export const routes: Routes = [
    { path: '',
    component: LoginComponent,
    children: [
      { path: '',    component: DoLoginComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule {}