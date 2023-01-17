import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KnowledgeComponent } from './pages/knowledge/knowledge.component';
import { TrashComponent } from './pages/trash/trash.component';

const routes: Routes = [
  { path: "manage-knowledge", component: KnowledgeComponent },
  { path: "trash", component: TrashComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KnowledgeRoutingModule { }
