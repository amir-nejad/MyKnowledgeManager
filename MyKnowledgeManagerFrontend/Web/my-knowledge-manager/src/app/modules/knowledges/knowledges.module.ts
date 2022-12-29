import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { KnowledgesRoutingModule } from './knowledges-routing.module';
import { KnowledgesComponent } from './pages/knowledges/knowledges.component';
import { KnowledgesListComponent } from './components/knowledges-list/knowledges-list.component';
import { CreateUpdateComponent } from './components/create-update/create-update.component';
import { DeleteTrashComponent } from './components/delete-trash/delete-trash.component';


@NgModule({
  declarations: [
    KnowledgesComponent,
    KnowledgesListComponent,
    CreateUpdateComponent,
    DeleteTrashComponent
  ],
  imports: [
    CommonModule,
    KnowledgesRoutingModule
  ]
})
export class KnowledgesModule { }
