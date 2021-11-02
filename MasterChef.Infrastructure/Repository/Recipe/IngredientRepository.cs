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
	public class IngredientRepository : IIngredientRepository
	{
		private string _connectionString;

		public IngredientRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task DeleteAsync(Guid uid)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"delete from TbIngredient where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", uid);

				await db.ExecuteAsync(query, parameters);
			}
		}

		public async Task<IngredientDto> GetAsync(Guid uid)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"select 
								UID,
								UIDRecipe,
								Description,
								ValueMeasure,
								Measure
							from TbIngredient
							where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", uid);

				return await db.QueryFirstOrDefaultAsync<IngredientDto>(query, parameters);
			}
		}

		public async Task<IEnumerable<IngredientDto>> GetListAsync()
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"select 
								UID,
								UIDRecipe,
								Description,
								ValueMeasure,
								Measure
							from TbIngredient";

				return await db.QueryAsync<IngredientDto>(query);
			}
		}

		public async Task<IEnumerable<IngredientDto>> GetListByRecipeAsync(Guid uidRecipe)
		{
			try
			{
				using (IDbConnection db = new SqlConnection(_connectionString))
				{
					var query = $@"select 
								UID,
								UIDRecipe,
								Description,
								ValueMeasure,
								Measure
							from TbIngredient
							where UIDRecipe = @uidRecipe";

					var parameters = new DynamicParameters();
					parameters.Add("@uidRecipe", uidRecipe);

					return await db.QueryAsync<IngredientDto>(query, parameters);
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task InsertAsync(IngredientDto recipe)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"insert into TbIngredient (
								UID,
								UIDRecipe,
								Description,
								ValueMeasure,
								Measure
							) values (
								@uid, 
								@uidRecife, 
								@description, 
								@valueMeasure, 
								@measure);";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", recipe.UID);
				parameters.Add("@uidRecife", recipe.UIDRecipe);
				parameters.Add("@description", recipe.Description);
				parameters.Add("@valueMeasure", recipe.ValueMeasure);
				parameters.Add("@measure", recipe.Measure);

				await db.ExecuteAsync(query, parameters);
			}
		}

		public async Task UpdateAsync(IngredientDto recipe)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"update TbIngredient set 
								UIDRecipe = @uidRecife, 
								Description = @description, 
								valueMeasure = @valueMeasure, 
								Measure = @measure 
							where UID = @uid";

				var parameters = new DynamicParameters();
				parameters.Add("@uid", recipe.UID);
				parameters.Add("@uidRecife", recipe.UIDRecipe);
				parameters.Add("@description", recipe.Description);
				parameters.Add("@valueMeasure", recipe.ValueMeasure);
				parameters.Add("@measure", recipe.Measure);

				await db.ExecuteAsync(query, parameters);
			}
		}
	}
}
