using Ex2.Model.EventArgs;
using Ex2.Models.Interface;
using Ex2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models
{
    class JoystickModel : BaseNotify,IJoystickModel
    {
       
        public new event PropertyChangedEventHandler PropertyChanged;
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                {
                    NotifyPropertyChanged("Throttle");
                }
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                aileron = value;
                {
                    NotifyPropertyChanged("Aileron");
                }
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                {
                    NotifyPropertyChanged("Elevator");
                }
            }
        }
        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                {
                    NotifyPropertyChanged("Rudder");
                }

            }
        }
        public new void NotifyPropertyChanged(string propName){
if (this.PropertyChanged != null)
this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
}


    }
}
