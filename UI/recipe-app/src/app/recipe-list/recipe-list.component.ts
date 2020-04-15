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
  filteredRecipes : IRecipe[];
  imageWidth = 50;
  imageMargin = 2;
  
  _listFilter : string = '';
  get listFilter():string{
    return this._listFilter;
  }
  set listFilter(value:string){
    this._listFilter = value;
    this.filteredRecipes = this.listFilter ? this.performFilter(this.listFilter) :this.recipes;
  }

  constructor(private recipeService: RecipeService) { }


  performFilter(filterBy: string): IRecipe[] {
    filterBy = filterBy.toLocaleLowerCase();
    debugger;
    console.log(this.recipes.filter((recipe : IRecipe) => 
    recipe.recipeName.toLocaleLowerCase().indexOf(filterBy) > -1));
    return this.recipes.filter((recipe : IRecipe) => 
    recipe.recipeName.toLocaleLowerCase().indexOf(filterBy) > -1);
  }


  // ngOnInit() {
  //   this.recipeService.getRecipes().subscribe( 
  //    recipes => this.recipes = recipes,
  //     error => this.errorMessage = <any>error
  //   );
  //   this.filteredRecipes = this.recipes;
  // }

  //TODO: why before adding next the recipes were not loading? 
  ngOnInit(): void {
    this.recipeService.getRecipes().subscribe({
      next: recipes => {
        this.recipes = recipes;
        this.filteredRecipes = this.recipes;
      },
      error: err => this.errorMessage = err
    });
  }

}
