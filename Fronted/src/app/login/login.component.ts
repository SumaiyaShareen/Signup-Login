import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading: boolean = false;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const loginData = this.loginForm.value;
      this.isLoading = true;
      this.http.post('https://localhost:7049/api/UserDetail/login', loginData, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).subscribe(
        (response) => {
            console.log('Login successful', response);
            alert('Login successful!');
            this.router.navigate(['/dashboard']);
            this.loginForm.reset();
            this.isLoading = false;
        },
        (error) => {
            console.error('Login failed', error);
            const errorMessage = error.error?.message || 'An error occurred during login. Please try again.';
            alert(`Login failed: ${errorMessage}`);
            this.isLoading = false;
        }
    );
  }
}
}