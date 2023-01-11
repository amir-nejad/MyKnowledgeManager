import { Pipe, PipeTransform } from '@angular/core';
import { KnowledgeLevel } from '../enums/knowledge-level';

@Pipe({
  name: 'knowledgeLevel'
})
export class KnowledgeLevelPipe implements PipeTransform {

  transform(value: string, displayMode = false): string | number {
    if (!value) return value;

    if (displayMode) {
      switch (value) {
        case KnowledgeLevel.Beginner.toString():
          return "Beginner";
        case KnowledgeLevel.Intermediate.toString():
          return "Intermediate";
        case KnowledgeLevel.Advanced.toString():
          return "Advanced";
        case KnowledgeLevel.Expert.toString():
          return "Expert";
        default:
          return "";
      }
    } else {
      switch (value) {
        case KnowledgeLevel.Intermediate.toString():
          return KnowledgeLevel.Intermediate;
        case KnowledgeLevel.Advanced.toString():
          return KnowledgeLevel.Advanced;
        case KnowledgeLevel.Expert.toString():
          return KnowledgeLevel.Expert;
        default:
          return KnowledgeLevel.Beginner;
      }
    }
  }
}
