using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WindowsForms.Domain.Models
{
	public class User
	{

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Login { get; set; }
		public string PasswordHash { get; set; }
		public string Salt { get; set; }

		public User()
		{

		}

		public User(string login, string passwordHash, string salt)
		{
			Login = login;
			PasswordHash = passwordHash;
			Salt = salt;
		}
	}
}
