using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef.Domain.Dto
{
	public class UserDto
	{
		public Guid UID { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
