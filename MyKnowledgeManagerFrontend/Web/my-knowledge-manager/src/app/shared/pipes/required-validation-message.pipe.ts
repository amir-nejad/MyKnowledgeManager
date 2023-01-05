import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'requiredValidationMessage'
})
export class RequiredValidationMessagePipe implements PipeTransform {

  transform(fieldName: string): string {
    return `The ${fieldName} is required.`;
  }

}
