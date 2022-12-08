import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninRedirectCallbackComponent, SignoutRedirectCallbackComponent } from './core';
import { AuthenticationGuard } from './core/guards/authentication.guard';

const routes: Routes = [
  {
    path: 'knowledge-tags',
    loadChildren: () =>
      import('./modules/knowledge-tags/knowledge-tags.module').then((p) => p.KnowledgeTagsModule),
    canActivate: [AuthenticationGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
