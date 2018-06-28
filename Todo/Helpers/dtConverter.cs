using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Todo.Helpers
{
    public class dtConverter : IValueConverter
    {
        public object Convert(object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            var time = (DateTime)value;
            return time.ToString("M/d/yyyy h:mm tt");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
