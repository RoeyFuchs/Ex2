using Ex2.Model;
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
        private static Client m_Instance = null;
        bool ready = false;
        bool running = false;

        const int refreshMaxTime = 1;
        const string flush = "\r\n";
        const char parserSpliter = ',';
        
        #region Singleton
        public static Client Instance {
            get {
                if (m_Instance == null) {
                    m_Instance = new Client();
                }
                return m_Instance;
            }
        }

        #endregion
        
        private Client() {
            this.set = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
            this.parse = GetDictionary();
        }

        public void Start() {
            if(running) {
                return;
            } else {
                running = true;
            }
            const int TimeToReconnect = 4000;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdd = System.Net.IPAddress.Parse(this.set.FlightServerIP);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, this.set.FlightCommandPort);
            while(!ready) {
                try {
                    socket.Connect(remoteEP);
                    this.ready = true;
                    StatusViewModel.Instance.ClientStatus = true;
                } catch(SocketException e) {
                    System.Threading.Thread.Sleep(TimeToReconnect);
                }
            }


            while (socket.Connected && SocketConnected(socket)) {
                commands.TryTake(out string commnd, TimeSpan.FromSeconds(refreshMaxTime));
                commnd = commnd + flush;
                try {
                    socket.Send(System.Text.Encoding.ASCII.GetBytes(commnd));
                } catch (Exception) { }
            
            }
            StatusViewModel.Instance.ClientStatus = false;
        
            socket.Disconnect(false);
            socket.Close();
            running = false;
            ready = false;
        }

        public void addCommand(string str, bool atom) {
            if (atom) {
            this.commands.Add(str);
            } else {
                this.commands.Add(Parse(str));
            }
        }

        private string Parse(string str) {
            string[] words = str.Split(parserSpliter);
            string ParsedCmd = this.parse[words[0]];
            string Val = words[1];
            return ParsedCmd + " " + Val; ;
        }

        private Dictionary<string, string> GetDictionary() {
                XElement rootElement = XElement.Parse(File.ReadAllText(@xmlFile));
                var names = rootElement.Elements("Key").Elements("Name").Select(n => n.Value);
                var values = rootElement.Elements("Key").Elements("Value").Select(v => v.Value);
                var list = names.Zip(values, (k, v) => new { k, v }).ToDictionary(item => item.k, item => item.v);
                return list;
            }

        bool SocketConnected(Socket s) {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
    }

   

}

