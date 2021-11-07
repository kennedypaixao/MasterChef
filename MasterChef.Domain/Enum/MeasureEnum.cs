using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Enum
{
	public enum MeasureEnum
	{
		[Description("Xícara")]
		Xicara = 1,
		[Description("ML")]
		ML = 2,
		[Description("Grama")]
		Grama = 3,
		[Description("Colher Sopa")]
		ColherSopa = 4,
		[Description("Colher Café")]
		ColherCafe = 5,
		[Description("Colher Chá")]
		ColherCha = 6
	}
}
