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
        private ICommand _openSettingCommand;
        private ICommand _connectCommand;
        private ICommand _disconnectCommand;
        private Server serv;
        private Client cln;
        /// <summary>
        /// OpenSettingCommand
        /// </summary>
        public ICommand OpenSettingCommand {
                get {
                    return _openSettingCommand ?? (_openSettingCommand = new CommandHandler(() => OpenSettingsWin()));
                }
            }
        /// <summary>
        /// OpenSettingsWin
        /// </summary>
        public void OpenSettingsWin() {
                Window dig = new SettingWin();
                dig.Show();
            }
        /// <summary>
        /// ConnectCommand - connect to server
        /// </summary>
        public ICommand ConnectCommand {
            get {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => StartServerAndClient()));
            }
        }
        /// <summary>
        /// StartServer
        /// </summary>
        private void StartServerAndClient() {
            serv =  Server.Instance;
            cln = Client.Instance;
            //start server on new task
            Task serverTask = new Task(() => {
                serv.Start();
            });
            serverTask.Start();
            //start client on new task
            Task clientTask = new Task(() => {
                cln.Start();
            });

            clientTask.Start();
            //update status
            StatusViewModel.Instance.SetReadyToConnect();

        }
        /// <summary>
        /// DisconnectCommand - disconnect server
        /// </summary>
        public ICommand DisconnectCommand {
            get {
                return _disconnectCommand ?? (_disconnectCommand = new CommandHandler(() => StopServer()));
            }
        }
        /// <summary>
        /// StopServer
        /// </summary>
        private void StopServer() {
            if (cln != null && serv != null) {
                cln.Stop();
                serv.Stop();
            }
            
        }

    }
}
