using System.ComponentModel;

namespace Ex2.Models.Interface {
    interface IManualPilotModel {
        double Throttle { get; set; }
        double Rudder { get; set; }
        double Elevator { get; set; }
        double Aileron { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}
