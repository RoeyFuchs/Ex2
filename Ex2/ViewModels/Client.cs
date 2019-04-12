using Ex2.ViewModels.Windows;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Console.WriteLine();
        }

        void Start() {
            TcpClient tcpClient = new TcpClient(this.set.FlightServerIP, this.set.FlightCommandPort);
            while(tcpClient != null) {
                string r = commands.Take();
                byte[] bytes = Encoding.ASCII.GetBytes(r);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(bytes, 0, bytes.Length);
            }
            tcpClient.Close();
        }

        void addCommand(string str, bool atom) {
            this.commands.Add(str);
        }

        string Parse(string str) {
            return "lal";
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

