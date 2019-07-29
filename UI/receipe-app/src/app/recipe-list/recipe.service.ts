import { Injectable } from '@angular/core';
import { IRecipe } from './recipe';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class RecipeService {
    private recipeUrl = "https://localhost:44360/api/Recipes";

    constructor(private http: HttpClient) { }

    getRecipes(): Observable<IRecipe[]> {
        return this.http.get<IRecipe[]>(this.recipeUrl).pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
    }

    getRecipe(id : number): Observable<IRecipe>{
        return this.http.get<IRecipe>(this.recipeUrl + '/' + id).pipe(
        );
    }

    private handleError(err: HttpErrorResponse) {
        let errorMesssage = '';
        if (err.error instanceof ErrorEvent) {
            errorMesssage = `An error occured: ${err.error.message}`;
        }else{
            errorMesssage = `Server returned code: ${err.status}, error message is: ${err.message}`;         
        }
        console.error(errorMesssage);
        return throwError(errorMesssage);

    }

}   