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
                ServerConnectionStatus = ConnectionStatus.Disconnected,
                ClientConnectionStatus = ConnectionStatus.Disconnected
            };
        }

        public ConnectionStatus ServerConnectionStatus {
            get { return this.model.ServerConnectionStatus; }
        }

        public ConnectionStatus ClientConnectionStatus {
            get { return this.model.ClientConnectionStatus; }
        }

        public void SetReadyToConnect() {
            model.ServerConnectionStatus = ConnectionStatus.ReadyToConnect;
            model.ClientConnectionStatus = ConnectionStatus.ReadyToConnect;
            PropertyChanged(this, new PropertyChangedEventArgs("ServerConnectionStatus"));
            PropertyChanged(this, new PropertyChangedEventArgs("ClientConnectionStatus"));
        }

        bool _serverStatus;
        public bool ServerStatus {
            set {
                _serverStatus = value;
                if (value) {
                    model.ServerConnectionStatus = ConnectionStatus.Connected;
                } else {
                    model.ServerConnectionStatus = ConnectionStatus.Disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ServerConnectionStatus"));
            }
        }
        bool _clientStatus;
        public bool ClientStatus {
            set {
                _clientStatus = value;
                if (value) {
                    model.ClientConnectionStatus = ConnectionStatus.Connected;
                } else {
                    model.ClientConnectionStatus = ConnectionStatus.Disconnected;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ClientConnectionStatus"));
            }
        }

    }
}