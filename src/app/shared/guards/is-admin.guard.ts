import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { LocalStorageService, EmployeeDto } from '../index';

@Injectable()
export class IsAdminGuard implements CanActivate {

  localStorageService: LocalStorageService;
  router: Router;
  storedAuth: EmployeeDto;
  isAllowed: boolean;

  constructor(localStorageService: LocalStorageService, router: Router) {
    this.localStorageService = localStorageService;
    this.router = router;
  }

  /**
   * if stored login creds is admin then route is accessible
   */
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    const storageStream = this.localStorageService.get<EmployeeDto>('auth').subscribe();

    const localStorageGetStream = this.localStorageService.get<EmployeeDto>('auth')
    .subscribe((obj: EmployeeDto) => {
      this.storedAuth = obj;
      this.isAllowed = this.storedAuth.isAdmin;
    },
    err => { this.isAllowed = false; },
    () => { this.isAllowed = this.storedAuth.isAdmin; });

    if (!this.isAllowed){
      this.router.navigate(['/login']);
    }

    return this.isAllowed;
  }
}
