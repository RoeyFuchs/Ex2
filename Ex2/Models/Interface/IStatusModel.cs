using Ex2.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models.Interface
{
    interface IStatusModel
    {

        ConnectionStatus ServerConnectionStatus { set; get;}

        ConnectionStatus ClientConnectionStatus {set; get;}
    }
}
