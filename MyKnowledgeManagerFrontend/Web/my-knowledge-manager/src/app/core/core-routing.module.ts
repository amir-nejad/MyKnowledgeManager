import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticatedGuard } from '.';

const routes: Routes = [


  {
    path: 'authentication',
    loadChildren: () => import('./authentication/authentication.module').then(a => a.AuthenticationModule),
    canActivate: [AuthenticatedGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
