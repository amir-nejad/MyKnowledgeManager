import { RequiredValidationMessagePipe } from './required-validation-message.pipe';

describe('RequiredValidationMessagePipe', () => {
  it('create an instance', () => {
    const pipe = new RequiredValidationMessagePipe();
    expect(pipe).toBeTruthy();
  });
});
