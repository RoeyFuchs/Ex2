using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Ex2.Model;
using Ex2.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace Ex2.Views {
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl {
        ObservableDataSource<Point> planeLocations = null;


        public FlightBoard() {
            InitializeComponent();
            Server.Instance.PropertyChange += delegate (Object sender, PropertyChangedEventArgs e) {
                Vm_PropertyChanged(sender, e);
            };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        /// <summary>
        /// add a new point when notifyed
        /// </summary>
        /// <param name="sender">the notifer</param>
        /// <param name="e">the information</param>
        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            const char splitter = ',';
            const int longitudePlace = 0;
            const int latitudePlace = 1;

            string[] args = e.PropertyName.Split(splitter);
            Point p1 = new Point(double.Parse(args[longitudePlace]), double.Parse(args[latitudePlace]));
            planeLocations.AppendAsync(Dispatcher, p1);
        }

    }

}

