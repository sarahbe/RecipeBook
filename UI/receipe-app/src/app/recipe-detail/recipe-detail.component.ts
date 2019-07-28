import { Component, OnInit } from '@angular/core';
import { IRecipe } from '../recipe-list/recipe';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe: IRecipe;
  constructor() { }

  ngOnInit() {
  }

}
