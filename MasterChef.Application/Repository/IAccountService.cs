using MasterChef.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Application.Repository
{
	public interface IAccountService
	{
		Task<UserDto> ValidateUser(string email, string senha);
	}
}
