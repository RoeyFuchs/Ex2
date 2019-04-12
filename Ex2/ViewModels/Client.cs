using Ex2.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.ViewModels {
    public class Client {
        SettingsWindowViewModel set;
        Queue<string> commands = new Queue<string>();

        Client(SettingsWindowViewModel set) {
            this.set = set;
        }

        void Start() {
            TcpClient tcpClient = new TcpClient(this.set.FlightServerIP, this.set.FlightCommandPort);
            while(tcpClient != null) {
                
                string r = commands.Dequeue();
                byte[] bytes = Encoding.ASCII.GetBytes(r);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(bytes, 0, bytes.Length);
            }
            tcpClient.Close();
        }

        void addCommand(string str) {
            this.commands.Enqueue(str);
        }

    }
}
