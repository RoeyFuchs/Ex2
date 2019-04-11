using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ex2.Views
{
    public partial class ControlSide:UserControl {
        public ControlSide()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.JoystickViewModel();
        }

    }
}
