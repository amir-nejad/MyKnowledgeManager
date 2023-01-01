import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { KnowledgeRoutingModule } from './knowledge-routing.module';
import { DeleteTrashComponent } from './components/delete-trash/delete-trash.component';
import { CreateUpdateComponent } from './components/create-update/create-update.component';
import { KnowledgeListComponent } from './components/knowledge-list/knowledge-list.component';
import { KnowledgeComponent } from './pages/knowledge/knowledge.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    DeleteTrashComponent,
    CreateUpdateComponent,
    KnowledgeListComponent,
    KnowledgeComponent
  ],
  imports: [
    CommonModule,
    KnowledgeRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ]
})
export class KnowledgeModule { }
