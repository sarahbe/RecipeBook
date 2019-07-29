import { Component, OnInit } from '@angular/core';
import { IRecipe } from '../recipe-list/recipe';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from '../recipe-list/recipe.service';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe: IRecipe;
  constructor(private route:ActivatedRoute
    , private recipeService:RecipeService, private router: Router) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.recipeService.getRecipe(id).subscribe(
      recipe => this.recipe = recipe
    );
  }

  onBack() : void{
      this.router.navigate(['/recipes'])
  }

}
