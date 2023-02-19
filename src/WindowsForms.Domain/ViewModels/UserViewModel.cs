using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Domain.ViewModels
{
	public class UserViewModel
	{
		public string Login { get; set; } = String.Empty;
		public string Password { get; set; } = String.Empty;
		public UserViewModel(string login, string password)
		{
			Login = login;
			Password = password;
		}
	}
}
