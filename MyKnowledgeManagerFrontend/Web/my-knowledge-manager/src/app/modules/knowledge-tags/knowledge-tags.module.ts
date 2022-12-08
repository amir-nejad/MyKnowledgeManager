import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { CreateKnowledgeTagComponent } from './components/create-knowledge-tag/create-knowledge-tag.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { KnowledgeTagsRoutingModule } from './knowledge-tags-routing.module';



@NgModule({
  declarations: [
    CreateKnowledgeTagComponent
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
