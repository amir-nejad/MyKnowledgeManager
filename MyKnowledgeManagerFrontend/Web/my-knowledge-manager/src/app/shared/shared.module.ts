import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KnowledgeImportancePipe } from './pipes/knowledge-importance.pipe';
import { KnowledgeLevelPipe } from './pipes/knowledge-level.pipe';
import { RequiredValidationMessagePipe } from './pipes/required-validation-message.pipe';
import { ErrorComponent } from './pages/error/error.component';



@NgModule({
  declarations: [

    KnowledgeImportancePipe,
    KnowledgeLevelPipe,
    RequiredValidationMessagePipe,
    ErrorComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    KnowledgeImportancePipe,
    KnowledgeLevelPipe,
    RequiredValidationMessagePipe
  ]
})
export class SharedModule { }
