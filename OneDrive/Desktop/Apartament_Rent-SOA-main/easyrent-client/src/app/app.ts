import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './shared/components/navbar/navbar'; // <-- Notice it ends with /navbar because your file is named navbar.ts

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent], // <-- Registers it
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class AppComponent {
  title = 'easyrent-client';
}