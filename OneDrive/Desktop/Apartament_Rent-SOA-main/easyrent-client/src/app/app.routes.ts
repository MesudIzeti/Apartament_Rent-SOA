import { Routes } from '@angular/router';
import { LoginComponent } from './features/auth/login/login';
import { RegisterComponent } from './features/auth/register/register';
import { ApartmentListComponent } from './features/apartments/apartment-list/apartment-list';
import { ApartmentDetailComponent } from './features/apartments/apartment-detail/apartment-detail';
import { TenantBookingsComponent } from './features/dashboards/tenant-bookings/tenant-bookings';
import { LandlordPropertiesComponent } from './features/dashboards/landlord-properties/landlord-properties';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'apartments', component: ApartmentListComponent },
  { path: 'apartments/:id', component: ApartmentDetailComponent },
  { path: 'my-bookings', component: TenantBookingsComponent },           // Tenant route
  { path: 'manage-apartments', component: LandlordPropertiesComponent }, // Landlord route
  { path: '', redirectTo: '/apartments', pathMatch: 'full' }
];