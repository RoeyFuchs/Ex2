using Ex2.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
    }
}
