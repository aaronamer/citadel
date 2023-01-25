import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NameRepositoryService } from '../../services/namerepository.service';
import { notAllWhiteSpaceValidator } from '../../validators/notallwhitespace.validator';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  nameForm!: FormGroup;
  isSubmitted: boolean = false;
  submitSuccess?: boolean = undefined;
  lastNameSubmitted?: string = undefined;

  constructor(private formBuilder: FormBuilder, private nameRepository: NameRepositoryService) { }

  ngOnInit() {
    this.nameForm = this.formBuilder.group({
      nameField: ['', [Validators.required, notAllWhiteSpaceValidator()]]
    });
  }

  get nameField() {
    return this.nameForm.controls['nameField'];
  }

  onSubmit() {
    this.isSubmitted = true;

    var hasErrors;
    Object.keys(this.nameForm.controls).forEach(key => {
      if (this.nameForm.controls[key].errors) {
        hasErrors = true;
      }
    });

    if (hasErrors === true) {
      return;
    }

    this.nameRepository.add(this.nameField.value).subscribe(() => {
      this.lastNameSubmitted = this.nameField.value;
      this.submitSuccess = true;
      this.nameField.setValue('');
    },
    () => {
      this.submitSuccess = false;
    },
    () => {
        this.isSubmitted = false;
        setTimeout(() => { this.submitSuccess = undefined; }, 5000);
    });
  }
}
