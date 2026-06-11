import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../../../core/services/auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule
  ],
  templateUrl: './register.html',
  styleUrl: './register.scss'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  errorMessage: string = '';
  successMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      const userData = this.registerForm.value;
      
      this.authService.register(userData).subscribe({
        next: (response: any) => {
          this.successMessage = 'Registration successful! Redirecting to login...';
          setTimeout(() => {
            this.router.navigate(['/login']);
          }, 1500);
        },
        error: (err: any) => {
          console.error('API Error during registration:', err);
          
          // Simulation fallback when backend is offline or unreachable
          if (err.status === 0 || err.status === 404) {
            this.successMessage = 'Registration simulation successful (Local Mock)!';
            
            // Safe fallback interaction: store session data directly to browser storage
            localStorage.setItem('user_role', userData.role);
            localStorage.setItem('token', 'mock-development-jwt-token');
            
            setTimeout(() => {
              if (userData.role === 'Landlord') {
                this.router.navigate(['/manage-apartments']);
              } else {
                this.router.navigate(['/apartments']);
              }
            }, 1500);
          } else {
            this.errorMessage = err.error?.message || 'Registration failed. The email address might already be in use.';
          }
        }
      });
    } else {
      this.errorMessage = 'Please complete all fields with valid information before submitting.';
    }
  }
}