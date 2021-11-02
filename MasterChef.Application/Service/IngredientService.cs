using MasterChef.Application.Repository;
using MasterChef.Domain.Dto;
using MasterChef.Infrastructure.Repository.Recipe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterChef.Application.Service
{
	public class IngredientService : IIngredientService
	{
		private IIngredientRepository _ingredientRespository;

		public IngredientService(IIngredientRepository ingredientRespository)
		{
			_ingredientRespository = ingredientRespository;
		}

		public async Task DeleteAsync(Guid uid)
		{
			await _ingredientRespository.DeleteAsync(uid);
		}

		public async Task<IngredientDto> GetAsync(Guid uid)
		{
			return await _ingredientRespository.GetAsync(uid);
		}

		public async Task<IEnumerable<IngredientDto>> GetListAsync()
		{
			return await _ingredientRespository.GetListAsync();
		}

		public async Task<IEnumerable<IngredientDto>> GetListByRecipeAsync(Guid uidRecipe)
		{
			return await _ingredientRespository.GetListByRecipeAsync(uidRecipe);
		}

		public async Task InsertAsync(IngredientDto recipe)
		{
			await _ingredientRespository.InsertAsync(recipe);
		}

		public async Task UpdateAsync(IngredientDto recipe)
		{
			await _ingredientRespository.UpdateAsync(recipe);
		}
	}
}
