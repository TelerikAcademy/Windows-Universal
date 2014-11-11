using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ValueConversion.Converters
{
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            if (targetType != typeof(Brush))
            {
                return null;
            }

            int age = int.Parse(value.ToString());
            Brush brush;
            if (age > 25)
            {
                brush = new SolidColorBrush { Color = Colors.Red };
            }
            else
            {
                brush = new SolidColorBrush { Color = Colors.Yellow };
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
