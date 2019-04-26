using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ViewModels.Interfaces
{
    interface IJoystickViewModel {
        void NotifyPropertyChanged(string propName);
    }


}
