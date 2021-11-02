using MasterChef.Application.Repository;
using MasterChef.Domain.Dto;
using MasterChef.Infrastructure.Repository.Recipe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterChef.Application.Service
{
	public class RecipeService : IRecipeService
	{
		private IRecipeRepository _recipeRespository;
		private IIngredientService _ingredientService;

		public RecipeService(IRecipeRepository recipeRespository,
			IIngredientService ingredientService)
		{
			_recipeRespository = recipeRespository;
			_ingredientService = ingredientService;
		}

		public async Task DeleteAsync(Guid uid)
		{
			var recipes = await GetAsync(uid);

			foreach (var ingredient in recipes.Ingredients)
			{
				await _ingredientService.DeleteAsync(ingredient.UID);
			}

			await _recipeRespository.DeleteAsync(uid);
		}

		public async Task<RecipeDto> GetAsync(Guid uid)
		{
			var recipe = await _recipeRespository.GetAsync(uid);
			recipe.Ingredients = await _ingredientService.GetListByRecipeAsync(recipe.UID);

			return recipe;
		}

		public async Task<IEnumerable<RecipeDto>> GetListAsync()
		{
			var recipes =  await _recipeRespository.GetListAsync();

			foreach (var recipe in recipes)
			{
				recipe.Ingredients = await _ingredientService.GetListByRecipeAsync(recipe.UID);
			}

			return recipes;
		}

		public async Task InsertAsync(RecipeDto recipe)
		{
			await _recipeRespository.InsertAsync(recipe);
		}

		public async Task UpdateAsync(RecipeDto recipe)
		{
			await _recipeRespository.UpdateAsync(recipe);
		}

	}
}
