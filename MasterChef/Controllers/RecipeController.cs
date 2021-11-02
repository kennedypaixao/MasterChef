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
	public class RecipeController : Controller
	{
		private IRecipeService _recipeService;

		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet]
		[Route("[controller]/Get")]
		public async Task<ActionResult<RecipeDto>> GetAsync(Guid uid)
		{
			var data = await _recipeService.GetAsync(uid);

			if (data != null)
			{
				return Ok(data);
			}

			return NotFound();
		}

		[HttpGet]
		[Route("[controller]/GetList")]
		public async Task<ActionResult<IEnumerable<RecipeDto>>> GetListAsync()
		{
			var data = await _recipeService.GetListAsync();

			if (data != null)
			{
				return Ok(data);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("[controller]/Insert")]
		public async Task<ActionResult> Insert(RecipeDto recipe)
		{
			try
			{
				await _recipeService.InsertAsync(recipe);
				return Ok();
			}
			catch (Exception e)
			{
				return Problem(e.ToString());
			}
		}

		[HttpPut]
		[Route("[controller]/Update")]
		public async Task<ActionResult> Update(RecipeDto recipe)
		{
			try
			{
				await _recipeService.UpdateAsync(recipe);
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
				await _recipeService.DeleteAsync(uid);
				return Ok();
			}
			catch (Exception e)
			{
				return Problem(e.ToString());
			}
		}
	}
}
