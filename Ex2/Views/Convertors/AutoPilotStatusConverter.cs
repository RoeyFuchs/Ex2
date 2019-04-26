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
    class AutoPilotStatusToColorConverter : IValueConverter
    {
        const string busyColor = "White";
         const string freeColor = "#F09494";
        //convert status to color
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AutoPilotStatus)
            {
                AutoPilotStatus status = (AutoPilotStatus)value;
                if (status==AutoPilotStatus.Busy)
                {
                    return busyColor;
                }
                else if (status==AutoPilotStatus.Free)
                {
                    return freeColor;
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
