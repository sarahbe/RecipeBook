import { TestBed, async, inject } from '@angular/core/testing';

import { RecipeDetailGuard } from './recipe-detail.guard';

describe('RecipeDetailGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecipeDetailGuard]
    });
  });

  it('should ...', inject([RecipeDetailGuard], (guard: RecipeDetailGuard) => {
    expect(guard).toBeTruthy();
  }));
});
