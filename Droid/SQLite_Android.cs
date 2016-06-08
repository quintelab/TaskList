using System;
using ToDo.Droid;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace ToDo.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "ToDo.db";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}