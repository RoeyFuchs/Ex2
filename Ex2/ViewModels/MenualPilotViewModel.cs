using Ex2.Model.EventArgs;
using Ex2.Models.Interface;
using Ex2.ViewModels.Interfaces;
using Ex2.Views;
using System;
using System.ComponentModel;


namespace Ex2.ViewModels {
    class MenualPilotViewModel : IMenualPilotViewModel {
        Client client;
        IMenualPilotModel model;
        Joystick joystick;

        const int placesAfterDot = 3; //how many placse after dot to round

        public MenualPilotViewModel(IMenualPilotModel model, Joystick joystick) {
            client = Client.Instance;
            this.model = model;
            this.joystick = joystick;
            //set us as listener
            joystick.PropertyChanged +=
                   delegate (Object sender, PropertyChangedEventArgs e) {
                       NotifyPropertyChanged(e.PropertyName);
                   };
            model.PropertyChanged +=
             delegate (Object sender, PropertyChangedEventArgs e) {
                 NotifyPropertyChanged(e.PropertyName);
             };
            joystick.Moved += this.JoystickMoved;
        }

        public void JoystickMoved(object joy, VirtualJoystickEventArgs info) {
            model.Elevator = info.Elevator;
            model.Aileron = info.Aileron;
        }

        public double Throttle {
            get { return model.Throttle; }
            set {
                model.Throttle = Math.Round(value, placesAfterDot);
            }
        }

        public double Rudder {
            get { return model.Rudder; }
            set {
                model.Rudder = Math.Round(value, placesAfterDot); ;
            }
        }

        public void NotifyPropertyChanged(string propName) {
            client.AddCommand(propName, false);
        }

    }
}
