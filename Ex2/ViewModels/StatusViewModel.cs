using Ex2.Models;
using Ex2.Models.Interface;
using Ex2.Statuses;
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
            model = new StatusModel {
                ServerColor = ConnectionStatus.Disconnected,
                ClientColor = ConnectionStatus.Disconnected
            };
        }

        public ConnectionStatus ServerColor {
            get { return this.model.ServerColor; }
        }

        public ConnectionStatus ClientColor {
            get { return this.model.ClientColor; }
        }

        public void SetReadyToConnect() {
            model.ServerColor = ConnectionStatus.ReadyToConnect;
            model.ClientColor = ConnectionStatus.ReadyToConnect;
            PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
        }

        bool _serverStatus;
        public bool ServerStatus {
            set {
                _serverStatus = value;
                if (value) {
                    model.ServerColor = ConnectionStatus.Connected;
                } else {
                    model.ServerColor = ConnectionStatus.Disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            }
        }
        bool _clientStatus;
        public bool ClientStatus {
            set {
                _clientStatus = value;
                if(value) {
                    model.ClientColor = ConnectionStatus.Connected;
                } else {
                    model.ClientColor = ConnectionStatus.Disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
            }
        }

    }
}
