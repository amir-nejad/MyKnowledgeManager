import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TagsComponent } from './pages/tags/tags.component';

const routes: Routes = [
  { path: "manage-tags", component: TagsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KnowledgeTagsRoutingModule { }
