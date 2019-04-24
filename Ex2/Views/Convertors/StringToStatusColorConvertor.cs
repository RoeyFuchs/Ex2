using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ex2.Views.Convertors
{
    class StringToStatusColorConvertor : IValueConverter
    {
        const string _connected = "#008000"; //green
        const string _disconnected = "#FF0000"; //red
        const string _readyToConnect = "#FFDE00"; //yellow
        const string _green = "g";
        const string _red = "r";
        const string _yellow = "y";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorName = (string)value;
            if (string.Equals(colorName, _green))
            {
                return _connected;
            }
            else if (string.Equals(colorName, _yellow))
            {
                return _readyToConnect;
            }
            else if (string.Equals(colorName, _red))
            {
                return _disconnected;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
