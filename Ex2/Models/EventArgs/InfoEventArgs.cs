using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models.EventArgs {
    public class InfoEventArgs  {
    
        public InfoEventArgs(double lon, double lat) {
            Lon = lon;
            Lat = lat;
        }
        double Lon { get; set; }
        double Lat { get; set; }
    }
}
