using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo
{
	public partial class CreatePage : ContentPage
	{
		public List<ToDoItem> todoItems;
		private CreatePageViewModel vm;
		private int updateID = 0;

		public CreatePage (int id)
		{
			vm = new CreatePageViewModel ();
			BindingContext = vm;
			todoItems = new List<ToDoItem> ();
			InitializeComponent ();

			ToDoItem toDoItem = App.Database.GetToDo(id);
			ToDoEntry.Text = toDoItem.TaskName;
			Priority.Text = toDoItem.Priority;
			Date.Date = toDoItem.DueDate;
			Time.Time = toDoItem.DueDate.TimeOfDay;
			updateID = id;
		}

		public CreatePage ()
		{
			vm = new CreatePageViewModel ();
			BindingContext = vm;
			InitializeComponent ();
		}

		public void OnSave(object o, EventArgs e)
		{
			vm.AddTask (ToDoEntry.Text, Priority.Text, Date.Date, Time.Time.Hours, Time.Time.Minutes, Time.Time.Seconds, updateID, false);
			Clear ();
		}

		private void Clear()
		{
			ToDoEntry.Text = Priority.Text = string.Empty;
			Date.Date = DateTime.Now;
			Time.Time = new TimeSpan (DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
		}

		public void OnCancel(object o, EventArgs e)
		{
		}

		public void OnReview(object o, EventArgs e)
		{
			Clear ();
			Navigation.PushAsync (new ListTaskPage ());
		}
	}
}

