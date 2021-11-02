using Dapper;
using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Infrastructure.Repository.Recipe
{
	public class RecipeRepository : IRecipeRepository
	{
		private string _connectionString;

		public RecipeRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task DeleteAsync(Guid uid)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"delete from TbRecipe where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", uid);

				await db.ExecuteAsync(query, parameters);
			}
		}

		public async Task<RecipeDto> GetAsync(Guid uid)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"select 
								UID,
								Name
							from TbRecipe
							where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", uid);

				return await db.QueryFirstOrDefaultAsync<RecipeDto>(query, parameters);
			}
		}

		public async Task<IEnumerable<RecipeDto>> GetListAsync()
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"select 
								UID,
								Name
							from TbRecipe";

				return await db.QueryAsync<RecipeDto>(query);
			}
		}

		public async Task InsertAsync(RecipeDto recipe)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"insert into TbRecipe (
								UID,
								Name
							) values (
								@uid, 
								@name);";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", recipe.UID);
				parameters.Add("@name", recipe.Name);

				await db.ExecuteAsync(query, parameters);
			}
		}

		public async Task UpdateAsync(RecipeDto recipe)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"update TbRecipe set Name = @name where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", recipe.UID);
				parameters.Add("@name", recipe.Name);

				await db.ExecuteAsync(query, parameters);
			}
		}
	}
}
