using Ex2.Model.EventArgs;
using Ex2.Models;
using Ex2.Models.Interface;
using Ex2.ViewModels.Interfaces;
using Ex2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex2.ViewModels
{
    class JoystickViewModel : IJoystickViewModel
    {
        Client client;
        IJoystickModel model;
        Joystick joystick;

        const int placesAfterDot = 2;

        public JoystickViewModel(IJoystickModel model,Joystick joystick)
        {
            client = Client.Instance;
            this.model = model;
            this.joystick = joystick;
            joystick.PropertyChanged+=
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



        event PropertyChangedEventHandler IJoystickViewModel.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

       
        public void NotifyPropertyChanged(string propName)
        {
            client.AddCommand(propName, false);
        }
        
    }
}
