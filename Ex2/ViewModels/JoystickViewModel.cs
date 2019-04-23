﻿using Ex2.Model.EventArgs;
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

        public JoystickViewModel(IJoystickModel model, Joystick joystick)
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
            Console.WriteLine();
        }

        public void JoystickMoved(object joy, VirtualJoystickEventArgs info) {
            model.Elevator = info.Elevator;
            model.Aileron = info.Aileron;
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
