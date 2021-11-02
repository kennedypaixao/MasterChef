using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Infrastructure.Repository.Recipe
{
	public interface IRecipeRepository
	{
		public Task<IEnumerable<RecipeDto>> GetListAsync();
		public Task<RecipeDto> GetAsync(Guid uid);
		public Task InsertAsync(RecipeDto recipe);
		public Task UpdateAsync(RecipeDto recipe);
		public Task DeleteAsync(Guid uid);
	}
}
