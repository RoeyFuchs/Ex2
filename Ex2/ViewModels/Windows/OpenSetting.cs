using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ex2.Model;
using Ex2.Views.Windows;

namespace Ex2.ViewModels.Windows
{
        public class SettingAndServer {
            public SettingAndServer() {
            }
            private ICommand _openSettingCommand;
        private ICommand _connectCommand;
        private ICommand _disconnectCommand;
        private Server serv;
        private Client cln;
            
        public ICommand OpenSettingCommand {
                get {
                    return _openSettingCommand ?? (_openSettingCommand = new CommandHandler(() => MyAction()));
                }
            }
            public void MyAction() {
                Window dig = new SettingWin();
                dig.Show();
            }
        public ICommand ConnectCommand {
            get {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => StartServer()));
            }
        }
        private void StartServer() {
            serv =  Server.Instance;
            cln = Client.Instance;

            Task serverTask = new Task(() => {
                serv.Start();
            });
            serverTask.Start();

            Task clientTask = new Task(() => {
                cln.Start();
            });

            clientTask.Start();

            StatusViewModel.Instance.SetReadyToConnect();

        }

        public ICommand DisconnectCommand {
            get {
                return _disconnectCommand ?? (_disconnectCommand = new CommandHandler(() => StopServer()));
            }
        }

        private void StopServer() {
            cln.Stop();
            serv.Stop();
            
        }

    }
}
