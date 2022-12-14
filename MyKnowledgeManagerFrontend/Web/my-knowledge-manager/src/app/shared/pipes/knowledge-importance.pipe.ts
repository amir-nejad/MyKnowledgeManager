import { Pipe, PipeTransform } from '@angular/core';
import { KnowledgeImportance } from '../enums/knowledge-importance';

@Pipe({
  name: 'knowledgeImportance'
})
export class KnowledgeImportancePipe implements PipeTransform {

  transform(value: string, displayMode: boolean = false): string | number {
    if (!value) return value;

    if (displayMode) {
      switch (value) {
        case KnowledgeImportance.Important.toString():
          return "Important";
        case KnowledgeImportance.Neutral.toString():
          return "Neutral";
        case KnowledgeImportance.VeryImportant.toString():
          return "Very Important";
        default:
          return "";
      }
    } else {
      switch (value) {
        case KnowledgeImportance.Important.toString():
          return KnowledgeImportance.Important;
        case KnowledgeImportance.VeryImportant.toString():
          return KnowledgeImportance.VeryImportant;
        default:
          return KnowledgeImportance.Neutral;
      }
    }
  }

}
