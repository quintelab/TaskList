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
			var path = "/users/bravi/Data/ToDo.db";
			File.Open (path, FileMode.OpenOrCreate);
			var conn = new SQLite.SQLiteConnection (path);
			return conn;
		}
	}
}

