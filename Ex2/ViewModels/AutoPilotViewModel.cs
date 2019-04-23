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
using System.Threading;

namespace Ex2.ViewModels
{
    public class AutoPilotViewModel : INotifyPropertyChanged {
        private ICommand _clearCommand;
        private ICommand _sendCommand;
        private TimeSpan interval = TimeSpan.FromSeconds(2);

        const string busyColor = "#ff0000";
        const string freeColor = "#ff00b7";

        public event PropertyChangedEventHandler PropertyChanged;

        public AutoPilotViewModel() {
            BackColor = freeColor;
        }
           

        public string Text { get; set; }

        private string _backColor;
        public string BackColor {
            get { return _backColor; }
            set {
                _backColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackColor"));
            }
        }


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
                return _sendCommand ?? (_sendCommand = new CommandHandler(() => CreatSendTask()));
            }
        }

        private void CreatSendTask() {
            Task sendTask = new Task(() => {
                Send();
            });
            sendTask.Start();
        }


        private void Send() {
            BackColor = busyColor;
            string[] commands = Text.Split(
                                new[] { Environment.NewLine },
                                StringSplitOptions.None
                                );
            foreach (var c in commands) {
                Client.Instance.addCommand(c, true);
                Thread.Sleep(interval);
            }
            BackColor = freeColor;
        }
    }
}
