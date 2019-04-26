using Ex2.Models.Interface;
using Ex2.ViewModels;
using System.ComponentModel;

namespace Ex2.Models {
    class MenualPilotModel : BaseNotify, IMenualPilotModel {
        const string csvSplitter = ",";

        public new event PropertyChangedEventHandler PropertyChanged;
        private double throttle = 0.5; //starting point
        public double Throttle {
            get { return throttle; }
            set {
                throttle = value;
                {
                    NotifyPropertyChanged("Throttle" + csvSplitter + throttle);
                }
            }
        }
        private double rudder;
        public double Rudder {
            get { return rudder; }
            set {
                rudder = value;
                {
                    NotifyPropertyChanged("Rudder" + csvSplitter + rudder);
                }

            }
        }

        private double aileron;
        public double Aileron {
            get { return aileron; }
            set {
                aileron = value;
                {
                    NotifyPropertyChanged("Aileron" + csvSplitter + aileron);
                }

            }
        }

        private double elevator;
        public double Elevator {
            get { return elevator; }
            set {
                elevator = value;
                {
                    NotifyPropertyChanged("Elevator" + csvSplitter + elevator);
                }

            }
        }

        public new void NotifyPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
