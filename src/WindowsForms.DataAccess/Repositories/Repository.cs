using System.IO;
using System.Threading.Tasks;
using WindowsForms.DataAccess.Constants;
using WindowsForms.DataAccess.Interfaces.IRepositories;
using System.Data.SQLite;


namespace WindowsForms.DataAccess.Repositories
{
	public class Repository
	{

		public IUserRepository Users { get; set; }
		public SQLiteConnection myConnection;

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
			try
			{
				myConnection = new SQLiteConnection(DbConstants.CONNECTION_STRING);
				if (!File.Exists(DbConstants.CONNECTION_STRING))
				{
					//nothing
				}
				await myConnection.OpenAsync();
				string query = "CREATE TABLE users (Id INTEGER PRIMARY KEY , Login TEXT NOT NULL,  PasswordHash TEXT NOT NULL  ,  Salt TEXT NOT NULL )";
				SQLiteCommand sQLiteCommand = new SQLiteCommand(query, myConnection);
				var result = await sQLiteCommand.ExecuteNonQueryAsync();
				if (result == 0)
				{
					return false;
				}
				else return false;
			}
			catch
			{
				return false;
			}
			finally
			{
				myConnection.Close();
			}
		}
	}

}