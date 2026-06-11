import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-navbar', // or 'app-navigation' depending on your selector name
  standalone: true,
  imports: [CommonModule, RouterModule, MatButtonModule],
  templateUrl: './navbar.html', // make sure this matches your html file name exactly
  styleUrl: './navbar.scss'     // make sure this matches your scss file name exactly
})
export class NavbarComponent {
  constructor(private router: Router) {}

  getUserRole(): string {
    return localStorage.getItem('user_role') || '';
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('token') !== null;
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}