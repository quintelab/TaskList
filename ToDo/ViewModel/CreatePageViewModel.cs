﻿using System;

namespace ToDo
{
	public class CreatePageViewModel
	{
		public CreatePageViewModel ()
		{
		}

		public void AddTask(string todo, string priority, DateTime dueDate, int hour, int minute, int second, int updateID, bool isDeleted)
		{
			var newToDo = new ToDoItem {
				TaskName = todo,
				Priority = priority,
				DueDate = SetDueDate(dueDate, hour, minute, second),
				IsDeleted = isDeleted,
				ID = updateID
			};

			App.Database.SaveToDo (newToDo);
		}

		public DateTime SetDueDate(DateTime date, int hour, int minute, int second)
		{
			DateTime retVal = new DateTime (date.Year, date.Month, date.Day, hour, minute, second);
			return retVal;
		}
	}
}

