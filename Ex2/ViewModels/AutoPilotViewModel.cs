using Ex2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Ex2.Views;
using System.ComponentModel;

namespace Ex2.ViewModels
{
    public class AutoPilotViewModel : INotifyPropertyChanged {
        private ICommand _clearCommand;
        private ICommand _sendCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public AutoPilotViewModel() { }
           

        public string Text { get; set; }


        public ICommand ClearCommand {
            get {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearTextBox()));
            }
        }
        void ClearTextBox() {
            this.Text = String.Empty;
            PropertyChanged(this, new PropertyChangedEventArgs("Text"));
        }


        public ICommand SendCommand {
            get {
                return _sendCommand ?? (_sendCommand = new CommandHandler(() => Send()));
            }
        }
        void Send() {
            string[] commands = Text.Split(
    new[] { Environment.NewLine },
    StringSplitOptions.None
);
            foreach (var c in commands) {
                Console.WriteLine(c);
                Console.WriteLine("new");
            }
        }
    }
}
