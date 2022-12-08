import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateKnowledgeTagComponent } from './components/create-knowledge-tag/create-knowledge-tag.component';

const routes: Routes = [
  { path: "create", component: CreateKnowledgeTagComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KnowledgeTagsRoutingModule { }
