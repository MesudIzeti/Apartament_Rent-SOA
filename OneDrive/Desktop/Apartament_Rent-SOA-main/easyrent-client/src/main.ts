import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app'; // <-- Make sure this reads AppComponent

bootstrapApplication(AppComponent, appConfig) // <-- Make sure this reads AppComponent
  .catch((err) => console.error(err));