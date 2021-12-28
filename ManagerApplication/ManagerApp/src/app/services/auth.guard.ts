import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private router: Router) { }

  canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean | Promise<boolean> {
        var isAuthenticated = this.authService.getAuthStatus();
        var isManager = this.authService.isManager();
        var hasExpired = this.authService.hasExpired();
        if (!isAuthenticated || !isManager || hasExpired) {
            this.router.navigate(['/login']);
        }
        return isAuthenticated;
    }

}