using Ex2.Models;
using Ex2.ViewModels;
using System.Windows.Controls;


namespace Ex2.Views
{
    /// <summary>
    /// Interaction logic for ManualPilot.xaml
    /// </summary>
    public partial class ManualPilot : UserControl
    {
        public ManualPilot()
        {
            InitializeComponent();
            DataContext = new ManualPilotViewModel(new ManualPilotModel(), Joystick);
        }
    }
}
