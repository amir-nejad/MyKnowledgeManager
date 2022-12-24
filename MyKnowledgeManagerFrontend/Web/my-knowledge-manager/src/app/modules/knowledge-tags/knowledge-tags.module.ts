import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { KnowledgeTagsRoutingModule } from './knowledge-tags-routing.module';
import { TagsComponent } from './pages/tags/tags.component';
import { CreateUpdateComponent } from './components/create-update/create-update.component';



@NgModule({
  declarations: [
    TagsComponent,
    CreateUpdateComponent
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
