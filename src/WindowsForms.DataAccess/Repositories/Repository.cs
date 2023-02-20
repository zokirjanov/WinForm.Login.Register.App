using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Threading.Tasks;
using WindowsForms.DataAccess.Constants;
using WindowsForms.DataAccess.Interfaces.IRepositories;

namespace WindowsForms.DataAccess.Repositories
{
	public class Repository
	{

		public IUserRepository Users { get; set; }

		public Repository()
		{
			Users = new UserRepository();
		}
		public async void Initialize()
		{
				await CreateDataBaseAsync();
		}

		private async Task<bool> CreateDataBaseAsync()
		{
			SqliteConnection _sqliteConnection = new SqliteConnection(DbConstants.DB_Path_File);
			try
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				string dirpath = path + "\\WinForm";
				string filepath = dirpath + "\\winform-app.db";
				Directory.CreateDirectory(dirpath);
				File.WriteAllText(filepath, "");
				await _sqliteConnection.OpenAsync();
				string query = "CREATE TABLE users (id INTEGER PRIMARY KEY, Login TEXT NOT NULL UNIQUE, PasswordHash TEXT NOT NULL , Salt TEXT NOT NULL;)";
				SqliteCommand command = new SqliteCommand(query, _sqliteConnection);
				var result = await command.ExecuteNonQueryAsync();
				if (result == 0)
					return false;
				else
					return true;

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
	}

}