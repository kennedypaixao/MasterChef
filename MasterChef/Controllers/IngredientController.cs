using MasterChef.Application.Repository;
using MasterChef.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.API.Controllers
{
	[ApiController]
	public class IngredientController : Controller
	{
		private IIngredientService _ingredientService;

		public IngredientController(IIngredientService ingredientService)
		{
			_ingredientService = ingredientService;
		}

		[HttpGet]
		[Route("[controller]/Get")]
		public async Task<ActionResult<IngredientDto>> GetAsync(Guid uid)
		{
			var data = await _ingredientService.GetAsync(uid);

			if (data != null)
			{
				return Ok(data);
			}

			return NotFound();
		}

		[HttpGet]
		[Route("[controller]/GetList")]
		public async Task<ActionResult<IEnumerable<IngredientDto>>> GetListAsync()
		{
			var data = await _ingredientService.GetListAsync();

			if (data != null)
			{
				return Ok(data);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("[controller]/Insert")]
		public async Task<ActionResult> Insert(IngredientDto ingredient)
		{
			try
			{
				await _ingredientService.InsertAsync(ingredient);
				return Ok();
			}
			catch (Exception e)
			{
				return Problem(e.ToString());
			}
		}

		[HttpPut]
		[Route("[controller]/Update")]
		public async Task<ActionResult> Update(IngredientDto ingredient)
		{
			try
			{
				await _ingredientService.UpdateAsync(ingredient);
				return Ok();
			}
			catch (Exception e)
			{
				return Problem(e.ToString());
			}
		}

		[HttpDelete]
		[Route("[controller]/Delete")]
		public async Task<ActionResult> Delete(Guid uid)
		{
			try
			{
				await _ingredientService.DeleteAsync(uid);
				return Ok();
			}
			catch (Exception e)
			{
				return Problem(e.ToString());
			}
		}
	}
}
