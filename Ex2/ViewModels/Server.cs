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
        this.serv.Start();
        Console.WriteLine("Server has started on 127.0.0.1:{0}.{1}Waiting for a connection...", this.set.FlightInfoPort, Environment.NewLine);
        TcpClient client = this.serv.AcceptTcpClient();
        Console.WriteLine("A client connected.");
        NetworkStream ns = client.GetStream();
        while (client.Connected)  //while the client is connected, we look for incoming messages
        {
            byte[] msg = new byte[1024];     //the messages arrive as byte array
            ns.Read(msg, 0, msg.Length);
            string strMsg = Encoding.Default.GetString(msg);
            strMsg = strMsg.Split('\n')[0].Trim();

            string[] words = strMsg.Split(',');
            //the same networkstream reads the message sent by the client
            double lon = double.Parse(words[0]);
            double lat = double.Parse(words[1]);

        }
    }
}