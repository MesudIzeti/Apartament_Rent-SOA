import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() {}

  // Handles custom tenant/landlord roles based on email input
  login(credentials: any): Observable<any> {
    let detectedRole = 'Tenant';
    if (credentials.email && credentials.email.toLowerCase().includes('landlord')) {
      detectedRole = 'Landlord';
    }

    localStorage.setItem('token', 'mock-development-jwt-token');
    localStorage.setItem('user_role', detectedRole);

    return of({ 
      success: true, 
      token: 'mock-development-jwt-token',
      role: detectedRole 
    });
  }

  // 👇 ADDED: Fixed the registration page compiler error
  register(userData: any): Observable<any> {
    let assignedRole = userData.role || 'Tenant';
    if (userData.email && userData.email.toLowerCase().includes('landlord')) {
      assignedRole = 'Landlord';
    }

    return of({ 
      success: true, 
      message: 'Mock registration successful',
      role: assignedRole
    });
  }

  // 👇 ADDED: Fixed the Guards and Interceptors errors
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string {
    return localStorage.getItem('user_role') || 'Tenant';
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }

  logout(): void {
    localStorage.clear();
  }
}