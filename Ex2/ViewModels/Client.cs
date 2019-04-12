using Ex2.ViewModels.Windows;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ex2.ViewModels {
    public class Client {
        SettingsWindowViewModel set;
        BlockingCollection<string> commands = new BlockingCollection<string>();
        Dictionary<string, string> parse;
        static string xmlFile = "xmlFile.xml";

        public Client(SettingsWindowViewModel set) {
            this.set = set;
            this.parse = GetDictionary();
            this.Start();
        }

        void Start() {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdd = System.Net.IPAddress.Parse(this.set.FlightServerIP);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, this.set.FlightCommandPort);
            socket.Connect(remoteEP);
            while (socket.Connected) {
                string r = commands.Take() + "\r\n";
                socket.Send(System.Text.Encoding.ASCII.GetBytes(r));   
            }
            socket.Disconnect(false);
            socket.Close();
        }

        void addCommand(string str, bool atom) {
            if (atom) {
            this.commands.Add(str);
            } else {
                this.commands.Add(Parse(str));
            }
        }

        string Parse(string str) {
            string[] words = str.Split(',');
            string ParsedCmd = this.parse[words[0]];
            string Val = words[1];
            return ParsedCmd + " " + Val; ;
        }

        Dictionary<string, string> GetDictionary() {
                XElement rootElement = XElement.Parse(File.ReadAllText(@xmlFile));
                var names = rootElement.Elements("Key").Elements("Name").Select(n => n.Value);
                var values = rootElement.Elements("Key").Elements("Value").Select(v => v.Value);
                var list = names.Zip(values, (k, v) => new { k, v }).ToDictionary(item => item.k, item => item.v);
                return list;
            }

        }
          
    }

