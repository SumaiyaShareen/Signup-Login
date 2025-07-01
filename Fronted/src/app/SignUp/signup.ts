import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  standalone: false,
  templateUrl: './signup.html',
  styleUrls: ['./signup.css']
})
export class SignupComponent {
  signupForm: FormGroup;
  message = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      passwordHash: ['', [Validators.required, Validators.minLength(6)]],
      fullName: ['']
    });
  }

  onSubmit() {
    if (this.signupForm.valid) {
      this.http.post('https://localhost:7217/api/User/signup', this.signupForm.value)
        .subscribe({
          next: () => this.message = 'Signup successful!',
          error: err => this.message = err.error || 'Signup failed.'
        });
    } else {
      this.message = 'Please fill in all required fields correctly.';
    }
  }
}
