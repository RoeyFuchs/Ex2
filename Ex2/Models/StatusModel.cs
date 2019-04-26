using Ex2.Models.Interface;
using Ex2.Statuses;

namespace Ex2.Models {
    class StatusModel : IStatusModel {
        public ConnectionStatus ServerConnectionStatus {
            set; get;
        }

        public ConnectionStatus ClientConnectionStatus {
            set; get;
        }
    }
}
