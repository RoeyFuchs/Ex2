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
using Ex2.Statuses;

namespace Ex2.ViewModels
{
        public class AutoPilotViewModel : INotifyPropertyChanged
        {
            private ICommand _clearCommand;
            private ICommand _sendCommand;
            private TimeSpan interval = TimeSpan.FromSeconds(2);
            private AutoPilotModel model;

            public event PropertyChangedEventHandler PropertyChanged;

            public AutoPilotViewModel()
            {
                model = new AutoPilotModel();
            }


            public string Text
            {
                get
                {
                    return model.Text;
                }
                set
                {
                    model.Text = value;
                    if (value != String.Empty)
                    {
                        Sent = false;
                    }
                    else
                    {
                        Sent = true;
                    }
                }
            }
            public AutoPilotStatus BackColor
            {
                get
                {
                    if (model.Sent)
                    {
                    return AutoPilotStatus.Busy;
                    }
                    else
                    {
                    return AutoPilotStatus.Free;
                }
                }
            }
            private bool Sent
            {
                set
                {
                    model.Sent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BackColor"));
                }
            }


            public ICommand ClearCommand
            {
                get
                {
                    return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClearTextBox()));
                }
            }
            void ClearTextBox()
            {
                Text = String.Empty;
                PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }


            public ICommand SendCommand
            {
                get
                {
                    return _sendCommand ?? (_sendCommand = new CommandHandler(() => CreateSendTask()));
                }
            }
        /// <summary>
        /// CreateSendTask - create new task for send function execution
        /// </summary>
        private void CreateSendTask()
            {
                Task sendTask = new Task(() =>
                {
                    Send();
                });
                sendTask.Start();
            }

        /// <summary>
        /// Send - Add new commands to send to the server
        /// </summary>
        private void Send()
            {
                string[] commands = model.GetCommands();
            //send all commands - one by one
                foreach (var c in commands)
                {
                    Client.Instance.AddCommand(c, true);
                    Thread.Sleep(interval);
                }
                Sent = true;
            }
    }
}