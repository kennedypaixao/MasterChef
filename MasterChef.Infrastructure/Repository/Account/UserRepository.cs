using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MasterChef.Infrastructure.Repository.Account
{
	public class UserRepository : IUserRepository
	{
		private string _connectionString;

		public UserRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<UserDto> GetAsync(string email, string password)
		{
			using (IDbConnection db = new SqlConnection(_connectionString))
			{
				var query = $@"select 
									UID,
									Email,
									Password
								from TbUser
							where Email = @email and Password = @password;";

				var parameters = new DynamicParameters();
				parameters.Add("@email", email);
				parameters.Add("@password", password);

				return await db.QueryFirstOrDefaultAsync<UserDto>(query, parameters);
			}
		}
	}
}
