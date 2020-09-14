using System;
using System.Globalization;
using System.Windows.Data;

namespace PrismSample.ReactiveMvvm
{
	public class StringToNullableIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return string.Empty;
			else
				return value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (string.IsNullOrEmpty(value?.ToString()))
				return null;

			var newValue = 0;

			if (int.TryParse(value?.ToString(), out newValue))
				return newValue;
			else
				return null;
		}
	}
}
