using Ex2.Models.Interface;
using Ex2.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models {
    class StatusModel : IStatusModel{
        public ConnectionStatus ServerConnectionStatus {
            set; get;
        }

        public ConnectionStatus ClientConnectionStatus {
            set; get;
        }
    }
}
