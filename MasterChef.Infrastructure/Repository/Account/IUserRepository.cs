using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Infrastructure.Repository.Account
{
	public interface IUserRepository
	{
		public Task<UserDto> Get(string email, string password);
	}
}
