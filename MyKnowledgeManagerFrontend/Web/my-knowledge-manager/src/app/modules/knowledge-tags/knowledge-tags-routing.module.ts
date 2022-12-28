import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TagsComponent } from './pages/tags/tags.component';
import { TrashComponent } from './pages/trash/trash.component';

const routes: Routes = [
  { path: "manage-tags", component: TagsComponent },
  { path: "trash", component: TrashComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KnowledgeTagsRoutingModule { }
