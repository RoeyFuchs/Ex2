using Ex2.Model;
using Ex2.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace Ex2.Views.Windows
{
    /// <summary>
    /// Interaction logic for connectwin.xaml
    /// </summary>
    public partial class SettingWin : Window
    {
        public SettingWin()
        {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
