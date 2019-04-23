using Ex2.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models {
    class StatusModel : IStatusModel{
        public string ServerColor {
            set; get;
        }

        public string ClientColor {
            set; get;
        }
    }
}
