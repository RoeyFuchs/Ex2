using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ex2.Model;
using Ex2.Views.Windows;

namespace Ex2.ViewModels.Windows
{
        public class OpenSetting {
            public OpenSetting() {
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
                Window dig = new SettingWin();
                dig.Show();
            }
        }
}
