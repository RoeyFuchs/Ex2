using Ex2.Model.EventArgs;
using Ex2.Models.Interface;
using Ex2.ViewModels.Interfaces;
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
        public event PropertyChangedEventHandler PropertyChanged;
        IJoystickModel model;

        public JoystickViewModel(IJoystickModel model)
        {
            this.model = model;
            model.PropertyChanged += 
            delegate (Object sender, PropertyChangedEventArgs e) {
            NotifyPropertyChanged(e.PropertyName);
};
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
            Console.WriteLine(propName);
        }



    }
}
