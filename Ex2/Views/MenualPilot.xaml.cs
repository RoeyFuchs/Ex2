using Ex2.Models;
using Ex2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex2.Views
{
    /// <summary>
    /// Interaction logic for MenualPilot.xaml
    /// </summary>
    public partial class MenualPilot : UserControl
    {
        public MenualPilot()
        {
            InitializeComponent();
            DataContext = new JoystickViewModel(Joystick);
        }
    }
}
