using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ex2.Views.Convertors
{
    class StringToColorConverter : IValueConverter
    {
        const string busyColor = "White";
         const string freeColor = "#F09494";
        const string whiteColor = "W";
        const string pinkColor = "P";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorName = (string)value;
            if (string.Equals(colorName, whiteColor))
            {
                return busyColor;
            }
            else if(string.Equals(colorName, pinkColor))
            {
                return freeColor;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
