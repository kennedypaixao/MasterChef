using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Dto
{
	public class RecipeDto
	{
		public Guid UID { get; set; }
		public string Name { get; set; }
		public IEnumerable<IngredientDto> Ingredients { get; set; }
	}
}
