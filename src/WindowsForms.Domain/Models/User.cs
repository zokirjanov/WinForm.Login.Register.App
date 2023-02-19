using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Domain.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; } = String.Empty;
		public string PasswordHash { get; set; } = String.Empty;
		public string Salt { get; set; } = String.Empty;
		public User(string login, string password, string salt)
		{
			Login = login;
			PasswordHash = password;
			Salt = salt;
		}
	}
}
