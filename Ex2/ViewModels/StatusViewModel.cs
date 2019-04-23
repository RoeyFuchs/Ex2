using Ex2.Models;
using Ex2.Models.Interface;
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
        const string _connected = "#008000"; //green
        const string _disconnected = "#FF0000"; //red
        const string _readyToConnect = "#FFDE00"; //yellow
        IStatusModel model;

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
            model.ServerColor = _disconnected;
            model.ClientColor = _disconnected;
        }

        public string ServerColor {
            get { return this.model.ServerColor; }
        }

        public string ClientColor {
            get { return this.model.ClientColor; }
        }

        public void SetReadyToConnect() {
            model.ServerColor = _readyToConnect;
            model.ClientColor = _readyToConnect;
            PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
        }

        bool _serverStatus;
        public bool ServerStatus {
            set {
                _serverStatus = value;
                if (value) {
                    model.ServerColor = _connected;
                } else {
                    model.ServerColor = _disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            }
        }
        bool _clientStatus;
        public bool ClientStatus {
            set {
                _clientStatus = value;
                if(value) {
                    model.ClientColor = _connected;
                } else {
                    model.ClientColor = _disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
            }
        }

    }
}
