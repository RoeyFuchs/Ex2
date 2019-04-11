using Ex2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex2.ViewModels.Windows {
    class Connect {
        public Connect() {
            _canExecute = true;
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand {
            get {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction()));
            }
        }
        private bool _canExecute;
        public void MyAction() {
            Server serv = new Server();
            serv.Start();
        }
    }
}
