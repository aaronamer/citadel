import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function notAllWhiteSpaceValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {

    const value = control.value as string;

    if (value == null) {
      return null;
    }

    var result = (value.trim().length == 0)
      ? { allWhiteSpace: true }
      : null;

    return result;
  }
}
