import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KnowledgeImportancePipe } from './pipes/knowledge-importance.pipe';
import { KnowledgeLevelPipe } from './pipes/knowledge-level.pipe';



@NgModule({
  declarations: [

    KnowledgeImportancePipe,
    KnowledgeLevelPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    KnowledgeImportancePipe,
    KnowledgeLevelPipe
  ]
})
export class SharedModule { }
