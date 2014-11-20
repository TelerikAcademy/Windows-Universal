using AcademyAlumni.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace AcademyAlumni
{
    public class SeasonValueConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(string))
            {
                return null;
            }
            var season =(Season) value;

            if (season == Season.Season2010_2011)
            {
                return "Season 2010-2011";
            }
            else
            {
                return "other season";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
