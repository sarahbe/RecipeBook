import { Component, OnInit } from '@angular/core';
import { IRecipe } from './recipe';
import { RecipeService } from './recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  pageTitle: string = 'Recipe List';
  recipes: IRecipe[] = [];
  errorMessage: string;
  
  constructor(private recipeService: RecipeService) { }

  ngOnInit() {
    this.recipeService.getRecipes().subscribe(
      recipes => this.recipes = recipes,
      error => this.errorMessage = <any>error
    );
  }

}
