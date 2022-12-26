import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { KnowledgeTagsRoutingModule } from './knowledge-tags-routing.module';
import { TagsComponent } from './pages/tags/tags.component';
import { CreateUpdateComponent } from './components/create-update/create-update.component';
import { TagsListComponent } from './components/tags-list/tags-list.component';
import { DeleteTrashComponent } from './components/delete-trash/delete-trash.component';



@NgModule({
  declarations: [
    TagsComponent,
    CreateUpdateComponent,
    TagsListComponent,
    DeleteTrashComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    KnowledgeTagsRoutingModule
  ]
})
export class KnowledgeTagsModule { }
