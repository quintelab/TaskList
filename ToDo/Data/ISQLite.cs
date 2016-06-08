using System;
using SQLite;

namespace ToDo
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

