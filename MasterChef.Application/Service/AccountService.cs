using MasterChef.Application.Repository;
using MasterChef.Domain.Dto;
using MasterChef.Infrastructure.Repository.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Application.Service
{
	public class AccountService: IAccountService
	{
		private IUserRepository _userRepository;

		public AccountService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> ValidateUser(string email, string senha)
		{
			try
			{
				var user = await _userRepository.Get(email, senha);

				if (user != null)
				{
					return user;
				}
			}
			catch (Exception e)
			{

			}

			return new UserDto();
		}
	}
}
