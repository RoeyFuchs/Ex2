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
                _canExecute = true;
            }
            private ICommand _openSettingCommand;
        private ICommand _connectCommand;
            public ICommand OpenSettingCommand {
                get {
                    return _openSettingCommand ?? (_openSettingCommand = new CommandHandler(() => MyAction()));
                }
            }
            private bool _canExecute;
            public void MyAction() {
                Window dig = new SettingWin();
                dig.Show();
            }
        public ICommand ConnectCommand {
            get {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => StartServer()));
            }
        }
        public void StartServer() {
            Server serv = new Server();

            ThreadStart threadDelegate = new ThreadStart(serv.Start);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
        }
    }
}
