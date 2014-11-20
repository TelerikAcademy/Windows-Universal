using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace AttachedProperties.Converters
{
    public class ScaleValueConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = 6;
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
