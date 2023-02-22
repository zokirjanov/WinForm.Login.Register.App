using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsForms.DataAccess.Constants;
using WindowsForms.DataAccess.Interfaces.IRepositories;
using WindowsForms.Domain.Models;
using System.Data.SQLite;




namespace WindowsForms.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SQLiteConnection _con = new SQLiteConnection(DbConstants.CONNECTION_STRING);
		public async Task<bool> CreateAsync(User entity)
		{
			try
			{
				await _con.OpenAsync();
				string query = "insert into users(Login,PasswordHash,Salt) " +
					"values (@Login,@PasswordHash,@Salt);";
				SQLiteCommand command = new SQLiteCommand(query, _con)
				{
					Parameters =
					{
						new SQLiteParameter("Login",entity.Login),
						new SQLiteParameter("PasswordHash",entity.PasswordHash),
						new SQLiteParameter("Salt",entity.Salt)
					}
				};
				var result = await command.ExecuteNonQueryAsync();
				if (result == 0) return false; else return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				_con.Close();
			}
		}

		public async Task<User> FindByLoginAsync(string login)
		{
			try
			{
				await _con.OpenAsync();
				string query = $"select * from users where Login ='{login}';";
				SQLiteCommand command = new SQLiteCommand(query, _con);
				var readly = await command.ExecuteReaderAsync();
				if (await readly.ReadAsync())
				{
					User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3));
					user.Id = readly.GetInt32(0);
					return user;
				}
				else
				{
					return null;
				}
			}
			catch
			{
				return null;
			}
			finally
			{
				_con.Close();
			}
		}

		public Task<List<User>> GetAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task<User> GetAsync(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
