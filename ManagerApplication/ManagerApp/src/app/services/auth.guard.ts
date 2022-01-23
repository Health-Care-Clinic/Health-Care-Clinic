import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service";
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private router: Router, private _snackBar: MatSnackBar) { }

  canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean | Promise<boolean> {
        var isAuthenticated = this.authService.getAuthStatus();
        var isManager = this.authService.isManager();
        var hasExpired = this.authService.hasExpired();
        if (!isAuthenticated || !isManager || hasExpired) {
            this.router.navigate(['/login'])
            .then(_ => this._snackBar.open('Invalid username or password', 'Close', {duration: 3000}))
        }
        return isAuthenticated;
    }

}