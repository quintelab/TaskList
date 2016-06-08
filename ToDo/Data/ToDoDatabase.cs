using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
	public class ToDoDatabase
	{
		private SQLiteConnection database;
		static object locker = new object();

		public ToDoDatabase ()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<ToDoItem> ();
		}

		public ToDoItem GetToDo(int id)
		{
			lock (locker) {
				return database.Table<ToDoItem> ()
					.Where (c => c.ID == id)
					.FirstOrDefault ();
			}
		}

		public IEnumerable<ToDoItem> GetToDos()
		{
			lock (locker) {
				return (from c in database.Table<ToDoItem>()
				        select c).ToList();
			}
		}

		public int SaveToDo(ToDoItem toDoItem)
		{
			lock (locker) {
				if (toDoItem.ID != 0) {
					database.Update (toDoItem);
					return toDoItem.ID;
				} else {
					return database.Insert (toDoItem);
				}
			}
		}
	}
}

