using System;
using System.IO;
using ToDo.iOS;

[assembly:Xamarin.Forms.Dependency(typeof(SQLite_IOS))]
namespace ToDo.iOS
{
	public class SQLite_IOS : ISQLite
	{
		public SQLite_IOS ()
		{
		}

		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "ToDo.db";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}

