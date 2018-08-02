import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '../../../../node_modules/@angular/forms';
import { UserService } from '../../shared/services/user/user.service';
import { Router } from '../../../../node_modules/@angular/router';
import { User } from '../../shared/models/user';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {
  regForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl = 'tours';
  error = '';

  constructor(
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.regForm = this.formBuilder.group({
      firstName: ['', this.requiredFieldLength(2, 20)],
      lastName: ['', this.requiredFieldLength(2, 20)],
      email: ['', [Validators.required, Validators.email]],
      password: ['', this.requiredFieldLength(6, 20)],
      confirmPassword: ['', [Validators.required]]
    }, { validator: this.confirmValid('password','confirmPassword') });
  }

  requiredFieldLength(min: number, max: number) {
    return [
      Validators.required,
      Validators.minLength(min),
      Validators.maxLength(max)
    ]
  }
  // convenience getter for easy access to form fields
  get f_firstName() { 
    return this.regForm.controls.firstName;
  }

  get f_lastName() { 
    return this.regForm.controls.lastName;
  }

  get f_email() { 
    return this.regForm.controls.email;
  }
  
  get f_password() {
    return this.regForm.controls.password;
  }

  get f_confirmPassword() {
    return this.regForm.controls.confirmPassword;
  }

  confirmValid(pass: string, passConfirm: string) {
    return (group: FormGroup) => {
      let passwordInput = group.controls[pass],
          passConfirmInput = group.controls[passConfirm];
      if (passwordInput.value !== passConfirmInput.value) {
        return passConfirmInput.setErrors({notEquivalent: true})
      }
      else {
          return passConfirmInput.setErrors(null);
      }
    }
  }
  
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.regForm.invalid) {
      return;
    }

    this.loading = true;
    let newUser: User = {
      firstName: this.f_firstName.value,
      lastName: this.f_lastName.value,
      emailAddress: this.f_email.value,
      password: this.f_password.value
    }

    this.userService.register(newUser)
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }
}
