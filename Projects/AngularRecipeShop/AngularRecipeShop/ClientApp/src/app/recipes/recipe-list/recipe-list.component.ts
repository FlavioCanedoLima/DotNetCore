import { Component } from '@angular/core';
import { Recipe } from '../recipe.model';

@Component({
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html',
    styleUrls: ['./recipe-list.component.css']
})

export class RecipeListComponent {
    recipes: Recipe[] = [
        new Recipe('Canelone', 'Omelete e salsicha', 'https://goo.gl/KzLeji'),
        new Recipe('Crepe', 'Ovo e creme de leite', 'https://goo.gl/8N9BLP'),
        new Recipe('Ovos', 'Beneditinos de novela', 'https://goo.gl/bEM5hM')
    ];
}
