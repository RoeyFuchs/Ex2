using Ex2.Statuses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ex2.Views.Convertors
{
    class ConnectionStatusToColorConvertor : IValueConverter
    {
        const string _connected = "#008000"; //green
        const string _disconnected = "#FF0000"; //red
        const string _readyToConnect = "#FFDE00"; //yellow
        //convert status to color 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ConnectionStatus)
            {
                ConnectionStatus status = (ConnectionStatus)value;
                if (status==ConnectionStatus.Connected)
                {
                    return _connected;
                }
                else if (status==ConnectionStatus.ReadyToConnect)
                {
                    return _readyToConnect;
                }
                else if (status==ConnectionStatus.Disconnected)
                {
                    return _disconnected;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
