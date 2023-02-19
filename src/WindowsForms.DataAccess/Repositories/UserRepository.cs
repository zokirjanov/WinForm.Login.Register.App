using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsForms.DataAccess.Constants;
using WindowsForms.DataAccess.Interfaces.IRepositories;
using WindowsForms.Domain.Models;

namespace WindowsForms.DataAccess.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SqliteConnection _sqliteConnection = new SqliteConnection(DbConstants.DB_Path_File);

		public async Task<bool> CreateAsync(User entity)
		{

			try
			{
				await _sqliteConnection.OpenAsync();
				string query = "insert into users(login,password_hash,salt) " +
					"values (@login,@password_hash,@salt);";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection)
				{
					Parameters =
					{
						new SqliteParameter("login",entity.Login),
						new SqliteParameter("password_hash",entity.PasswordHash),
						new SqliteParameter("salt",entity.Salt)
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
				 _sqliteConnection.Close();
			}
		}

		public async Task<User> FindByLoginAsync(string login)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from users where login ='{login}';";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
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
				_sqliteConnection.Close();
			}
		}

		public async Task<List<User>> GetAllAsync()
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from users;";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				List<User> users = new List<User>();
				while (await readly.ReadAsync())
				{
					User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3));
					users.Add(user);
				}
				return users;

			}
			catch
			{
				return new List<User>();
			}
			finally
			{
				 _sqliteConnection.Close();
			}
		}

		public async Task<User> GetAsync(int id)
		{
			try
			{
				await _sqliteConnection.OpenAsync();
				string query = $"select * from users where id={id};";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var readly = await command.ExecuteReaderAsync();
				if (await readly.ReadAsync())
				{
					User user = new User(readly.GetString(1), readly.GetString(2), readly.GetString(3));
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
				_sqliteConnection.Close();
			}

		}

	}
}
