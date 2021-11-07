using MasterChef.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Dto
{
	public class IngredientDto
	{
		public Guid UID { get; set; }
		public Guid UIDRecipe { get; set; }
		public string Description { get; set; }
		public string ValueMeasure { get; set; }
		public MeasureEnum Measure { get; set; }

		public string MeasureDescription
		{
			get
			{
				return System.Enum.GetName(typeof(MeasureEnum), this.Measure);
			}
		}
	}
}
