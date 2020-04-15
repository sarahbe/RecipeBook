import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeDetailGuard implements CanActivate {
  constructor(private router:Router){
    
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      //plus sign means convert string to number
      let id = +next.url[1].path;
      if( isNaN(id) || id <1 )
      {
        alert("Invalid recipe ID");
        this.router.navigate(['/recipes']);
        //abort current operation
        return false;
      }
    return true;
  }
  
}
