﻿namespace Ex2.Model.Interface {
    public interface ISettingsModel {
        string FlightServerIP { get; set; }          // The IP Of the Flight Server
        int FlightInfoPort { get; set; }           // The Port of the Flight Server
        int FlightCommandPort { get; set; }           // The Port of the Flight Server

        void SaveSettings();
        void ReloadSettings();
    }
}
