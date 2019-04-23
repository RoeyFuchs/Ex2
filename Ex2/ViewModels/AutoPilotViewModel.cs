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
using Ex2.Models;

namespace Ex2.ViewModels
{
    public class AutoPilotViewModel : INotifyPropertyChanged {
        private ICommand _clearCommand;
        private ICommand _sendCommand;
        private TimeSpan interval = TimeSpan.FromSeconds(2);
        private AutoPilotModel model;

        const string busyColor = "White";
        const string freeColor = "#F09494";

        public event PropertyChangedEventHandler PropertyChanged;

        public AutoPilotViewModel() {
            model = new AutoPilotModel();
        }
           

        public string Text {
            get {
                return model.Text;
            }
            set {
                model.Text = value;
                if (value != String.Empty) {
                    Sent = false;
                } else {
                    Sent = true;
                }
            }
        }
        public string BackColor {
            get {
            if(model.Sent) {
                    return busyColor;
                } else {
                    return freeColor;
                }
                    }
        }
        private bool Sent {
            set {
                model.Sent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackColor"));
            }
        }


        public ICommand ClearCommand {
            get {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearTextBox()));
            }
        }
        void ClearTextBox() {
            Text = String.Empty;
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
            string[] commands = model.GetCommands();
            foreach (var c in commands) {
                Client.Instance.addCommand(c, true);
                Thread.Sleep(interval);
            }
            Sent = true;
        }
    }
}
