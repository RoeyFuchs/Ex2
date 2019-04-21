using Ex2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ex2.ViewModels {
    class StatusViewModel : INotifyPropertyChanged {
        private static StatusViewModel m_Instance = null;
        const string green = "#008000";
        const string red = "#FF0000";
        StatusModel model;

        public event PropertyChangedEventHandler PropertyChanged;


        #region Singleton
        public static StatusViewModel Instance {
            get {
                if (m_Instance == null) {
                    m_Instance = new StatusViewModel();
                }
                return m_Instance;
            }
        }
        #endregion

        private StatusViewModel() {
            model = new StatusModel();
            model.ServerColor = red;
            model.ClientColor = red;
        }

        public string ServerColor {
            get { return this.model.ServerColor; }
        }

        public string ClientColor {
            get { return this.model.ClientColor; }
        }



        bool _serverStatus;
        public bool ServerStatus {
            set {
                _serverStatus = value;
                if (value) {
                    model.ServerColor = green;
                } else {
                    model.ServerColor = red;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            }
        }
        bool _clientStatus;
        public bool ClientStatus {
            set {
                _clientStatus = value;
                if(value) {
                    model.ClientColor = green;
                } else {
                    model.ClientColor = red;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
            }
        }

    }
}
