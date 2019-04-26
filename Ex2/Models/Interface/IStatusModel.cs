using Ex2.Statuses;

namespace Ex2.Models.Interface {
    interface IStatusModel {

        ConnectionStatus ServerConnectionStatus { set; get; }
        ConnectionStatus ClientConnectionStatus { set; get; }
    }
}
