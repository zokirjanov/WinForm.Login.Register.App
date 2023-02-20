using System;
using System.Data.SQLite;
using System.IO;

namespace WindowsForms.DataAccess.Constants
{
	public class DbConstants
	{
		static public string DB_Path_Directory = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Win Forms";

		static public string DB_Path_File = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Win Fonms" + "\\win-form.db";

		//public static string DB_Path_File = "Data Source = C:\\Users\\davok\\OneDrive\\Рабочий стол\\WinForm.Login.Register.App\\win-form.db;";
	}
}
