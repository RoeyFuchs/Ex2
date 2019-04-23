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
        bool needStop = false;

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
        /// <summary>
        /// Start - opens connection and send data to our server
        /// </summary>
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
            //As long as the client is not logged in - we will attempt to connect
            while (!ready && !needStop) {
                try {
                    socket.Connect(remoteEP);
                    this.ready = true;
                    StatusViewModel.Instance.ClientStatus = true;
                } catch (SocketException)
                {
                    System.Threading.Thread.Sleep(TimeToReconnect);
                }
            }


            while (socket.Connected && SocketConnected(socket) && !needStop) {
                //Tries to remove an item from the BlockingCollection
                commands.TryTake(out string commnd, TimeSpan.FromSeconds(refreshMaxTime));
                commnd = commnd + flush;
                try {
                    socket.Send(System.Text.Encoding.ASCII.GetBytes(commnd));
                } catch (Exception) { }
            
            }
            //client is not logged in anymore
            StatusViewModel.Instance.ClientStatus = false;
            if (ready) {
                socket.Disconnect(false);
                socket.Close();
            }
            running = false;
            ready = false;
            needStop = false;
        }

        /// <summary>
        /// addCommand -add new command that will send to our server
        /// </summary>
        /// <param name="str"></param>
        /// <param name="atom"></param>
        public void addCommand(string str, bool atom) {
            if (atom) {
            this.commands.Add(str);
            } else {
                this.commands.Add(Parse(str));
            }
        }
        /// <summary>
        /// Parse  -change str format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string Parse(string str) {
            string[] words = str.Split(parserSpliter);
            string ParsedCmd = this.parse[words[0]];
            string Val = words[1];
            return ParsedCmd + " " + Val; ;
        }

        /// <summary>
        /// GetDictionary - read paths of setting from xml file
        /// </summary>
        /// <returns>dictionary of settings and its path</returns>
        private Dictionary<string, string> GetDictionary() {
                XElement rootElement = XElement.Parse(File.ReadAllText(@xmlFile));
                var names = rootElement.Elements("Key").Elements("Name").Select(n => n.Value);
                var values = rootElement.Elements("Key").Elements("Value").Select(v => v.Value);
                var list = names.Zip(values, (k, v) => new { k, v }).ToDictionary(item => item.k, item => item.v);
                return list;
            }
        /// <summary>
        /// SocketConnected - check given socket is alredy connected
        /// </summary>
        /// <param name="s"></param>
        /// <returns>true if socket is connected or false otherwise</returns>
        bool SocketConnected(Socket s) {
            //determine the status of the socket
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            //check if no data been received from the network.
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }

        public void Stop() {
            if (!running) return;
            needStop = true;
        }
    }

   

}

