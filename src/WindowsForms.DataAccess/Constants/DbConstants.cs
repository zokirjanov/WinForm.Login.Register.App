using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.DataAccess.Constants
{
	public class DbConstants
	{
		static public string DB_Path_Directory = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WinForms";

		static public string DB_Path_File = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\WinForms" + "\\winform-app.db";

	}
}
