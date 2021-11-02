using MasterChef.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : Controller
	{
		private IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAsync(string email, string password)
		{
			var user = await _accountService.ValidateUser(email, password);

			if (user != null)
			{
				return Ok();
			}

			return NotFound();
		}
	}
}
