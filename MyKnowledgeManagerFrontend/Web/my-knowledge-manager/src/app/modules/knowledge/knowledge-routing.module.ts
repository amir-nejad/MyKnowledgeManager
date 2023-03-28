import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KnowledgeComponent } from './pages/knowledge/knowledge.component';
import { TrashComponent } from './pages/trash/trash.component';
import { ViewKnowledgeComponent } from './pages/view-knowledge/view-knowledge.component';

const routes: Routes = [
  { path: "manage-knowledge", component: KnowledgeComponent },
  { path: "trash", component: TrashComponent },
  { path: "view-knowledge/:id", component: ViewKnowledgeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KnowledgeRoutingModule { }
