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
        const string comma = ",";
        const string falseName = "FALSE";
       
        public new event PropertyChangedEventHandler PropertyChanged;
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                {
                    NotifyPropertyChanged("Throttle"+comma+ throttle+comma+falseName);
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
                    NotifyPropertyChanged("Aileron"+comma+ aileron+comma+falseName);
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
                    NotifyPropertyChanged("Elevator"+comma+ elevator+comma+falseName);
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
                    NotifyPropertyChanged("Rudder"+comma+rudder+falseName+falseName);
                }

            }
        }
        public new void NotifyPropertyChanged(string propName){
if (this.PropertyChanged != null)
this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
}


    }
}
