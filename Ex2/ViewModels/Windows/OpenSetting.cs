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
            Server serv =  Server.Instance;
            Client cln = Client.Instance;
        
            ThreadStart threadDelegateServ = new ThreadStart(serv.Start);
            Thread newThreadServ = new Thread(threadDelegateServ);
            newThreadServ.Start();

            ThreadStart threadDelegateCln = new ThreadStart(cln.Start);
            Thread newThreadCln = new Thread(threadDelegateCln);
            newThreadCln.Start();

        }
    }
}
