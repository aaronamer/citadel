import { AbstractControl } from '@angular/forms';
import { notAllWhiteSpaceValidator } from './notallwhitespace.validator';

describe('notAllWhiteSpaceValidator', () => {
  it('should return no error when the value is not all whitespace', () => {
    const control = { value: 'Aaron' };

    var result = notAllWhiteSpaceValidator()(control as AbstractControl);

    expect(result).toBeNull();
  });

  it('should return an error when the value is all whitespace', () => {
    const control = { value: '   ' };

    var result = notAllWhiteSpaceValidator()(control as AbstractControl);

    expect(result).toBeTruthy();
    expect(result?.allWhiteSpace).toBeTruthy();
  });
});
