using System;
using Xamarin.Forms;

namespace ToDo
{
	public class DateTimeConverter : IValueConverter
	{
		public DateTimeConverter ()
		{
		}

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var time = (DateTime)value;
			return time.ToString ("dd/MM/yyyy hh:mm tt");
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

