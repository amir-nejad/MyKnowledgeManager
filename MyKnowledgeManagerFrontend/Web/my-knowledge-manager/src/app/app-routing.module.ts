import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninRedirectCallbackComponent, SignoutRedirectCallbackComponent } from './core';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { ErrorComponent } from './shared/pages/error/error.component';

const routes: Routes = [
  {
    path: 'knowledge-tags',
    loadChildren: () =>
      import('./modules/knowledge-tags/knowledge-tags.module').then((p) => p.KnowledgeTagsModule),
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'knowledge',
    loadChildren: () =>
      import('./modules/knowledge/knowledge.module').then((p) => p.KnowledgeModule),
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'error', component: ErrorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
