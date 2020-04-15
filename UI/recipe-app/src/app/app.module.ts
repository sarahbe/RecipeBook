import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipe-detail/recipe-detail.component';
import { HomeComponent } from './home/home.component';
import { RecipeAddComponent } from './recipe-add/recipe-add.component';
import { HttpClientModule } from '@angular/common/http';
import { RecipeDetailGuard } from './recipe-detail/recipe-detail.guard';
import { ReactiveFormsModule , FormsModule} from '@angular/forms';
import { ConvertToSpaces } from './shared/convert-to-spaces.pipi';

@NgModule({
  declarations: [
    AppComponent,
    RecipeListComponent,
    RecipeDetailComponent,
    HomeComponent,
    RecipeAddComponent,
    ConvertToSpaces
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      {path: 'recipes', component: RecipeListComponent},
      {path: 'recipes/:id', canActivate:[RecipeDetailGuard],component: RecipeDetailComponent},
      {path: 'new-recipe', component: RecipeAddComponent},
      {path: 'home', component: HomeComponent},
      {path: '', redirectTo: 'home', pathMatch:'full'},
      {path: '**', redirectTo: 'home', pathMatch:'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
