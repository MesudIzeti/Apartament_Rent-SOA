import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth';

export const roleGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const expectedRole = route.data['expectedRole'];
  const userRole = authService.getRole();

  if (authService.getToken() && userRole === expectedRole) {
    return true;
  }
  router.navigate(['/unauthorized']);
  return false;
};
