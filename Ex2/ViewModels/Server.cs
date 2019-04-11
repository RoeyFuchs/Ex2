using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

using System.Net.Sockets;
using Ex2.ViewModels.Windows;
using Ex2.Model;
using System.Threading;



class Server {
    SettingsWindowViewModel set;
    TcpListener serv;
    public Server() {
        this.set = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
    }
    public void Start() {
        this.serv = new TcpListener(IPAddress.Parse("127.0.0.1"), this.set.FlightInfoPort);
        Thread th = new Thread(this.Connect());

    }
     private void Connect() {
        this.serv.Start();
        Console.WriteLine("Server has started on 127.0.0.1:80.{0}Waiting for a connection...", Environment.NewLine);
        TcpClient client = this.serv.AcceptTcpClient();

        Console.WriteLine("A client connected.");
    }
}