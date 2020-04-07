import { Component, OnInit } from '@angular/core';
import { ICategory } from '../recipe-list/category';
import { RecipeService } from '../recipe-list/recipe.service';
// import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-recipe-add',
  templateUrl: './recipe-add.component.html',
  styleUrls: ['./recipe-add.component.css']
})
export class RecipeAddComponent implements OnInit {
  categories : ICategory[] = [];
  errorMessage : string;
  constructor(private recipeService : RecipeService) { }

  ngOnInit() {
    this.recipeService.getCategories().subscribe(
      categories => this.categories = categories,
      error => this.errorMessage = error
    );
  }

}
