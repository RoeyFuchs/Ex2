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

        public event PropertyChangedEventHandler PropertyChanged;


        #region Singleton
        public static StatusViewModel Instance {
            get {
                if (m_Instance == null) {
                    m_Instance = new StatusViewModel();
                    m_Instance.ServerColor = red;
                    m_Instance.ClientColor = red;
                }
                return m_Instance;
            }
        }
        #endregion

        private StatusViewModel() { }



        public string ServerColor {
            set; get;
        }

        public string ClientColor {
            set; get;
        }

        bool _serverStatus;
        public bool ServerStatus {
            set {
                _serverStatus = value;
                if (value) {
                    ServerColor = green;
                } else {
                    ServerColor = red;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ServerColor"));
            }
        }
        bool _clientStatus;
        public bool ClientStatus {
            set {
                _clientStatus = value;
                if(value) {
                    ClientColor = green;
                } else {
                    ClientColor = red;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ClientColor"));
            }
        }

    }
}
