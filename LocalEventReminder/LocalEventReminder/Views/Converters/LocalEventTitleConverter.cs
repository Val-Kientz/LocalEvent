using LocalEventReminder.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LocalEventReminder.Views.Converters
{
    public class LocalEventTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LocalEvent)
            {
                return ((LocalEvent)value).EventName + " - " + ((LocalEvent)value).CreationDate.ToShortDateString();
            }
            else
            {
                return "error, not an Event";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
