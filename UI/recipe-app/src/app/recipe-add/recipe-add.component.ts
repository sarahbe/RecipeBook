import { Component, OnInit } from '@angular/core';
import { ICategory } from '../recipe-list/category';
import { RecipeService } from '../recipe-list/recipe.service';
import { IRecipe } from '../recipe-list/recipe';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-recipe-add',
  templateUrl: './recipe-add.component.html',
  styleUrls: ['./recipe-add.component.css']
})
export class RecipeAddComponent implements OnInit {
  categories : ICategory[] = [];
  recipe : IRecipe;
  errorMessage : string;
  closeResult = '';
  recipeForm :FormGroup;

  constructor(private recipeService : RecipeService, formBuilder : FormBuilder) {
    this.recipeForm = formBuilder.group({
      recipeName: ''
    });

   }
  

  // onSubmit(){
  //   this.recipeService.saveRecipe(this.recipe).subscribe(
  //     data => console.log(data),
  //     error => console.log(error)
  //   );
  // }

  saveRecipe()
  {
    console.log(this.recipe);
    console.log(this.recipeForm.value);
    this.recipeService.saveRecipe(this.recipeForm.value).subscribe(
          data => console.log(data),
          error => console.log(error)
        );
  }

  ngOnInit() {
    this.recipeService.getCategories().subscribe({
      next: categories => 
      {
         this.categories = categories;
    },
    error:err => this.errorMessage = err
   } );
    console.log(this.categories);
    
  }

}
