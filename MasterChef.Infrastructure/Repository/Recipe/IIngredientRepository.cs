using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Infrastructure.Repository.Recipe
{
	public interface IIngredientRepository
	{
		public Task<IEnumerable<IngredientDto>> GetListAsync();
		public Task<IngredientDto> GetAsync(Guid uid);
		public Task<IEnumerable<IngredientDto>> GetListByRecipeAsync(Guid uidRecipe);
		public Task InsertAsync(IngredientDto recipe);
		public Task UpdateAsync(IngredientDto recipe);
		public Task DeleteAsync(Guid uid);
	}
}
