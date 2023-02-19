using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
			Users= new UserRepository();
		}

		private bool DataBaseExists()
		{
			string file = DbConstants.DB_Path_File.Split()[1];
			return new FileInfo(file).Exists;
		}

		public async void Initialize()
		{
			if (!DataBaseExists())
			{
				await CreateDataBaseAsync();
			}
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
				string query = "CREATE TABLE users (id INTEGER PRIMARY KEY, login TEXT NOT NULL UNIQUE, password_hash TEXT NOT NULL , salt TEXT NOT NULL;)";
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
