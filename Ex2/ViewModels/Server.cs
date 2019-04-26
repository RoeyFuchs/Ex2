using System.Text;
using System.Net;
using System.Net.Sockets;
using Ex2.ViewModels.Windows;
using Ex2.Model;
using System.ComponentModel;
using Ex2.ViewModels;

class Server : BaseNotify {
    SettingsWindowViewModel set;
    TcpListener serv;
    public event PropertyChangedEventHandler PropertyChange;
    private static Server m_Instance = null;
    bool running = false;
    bool needStop = false;

    const int bufferSize = 1024;
    const char msgSplitter = '\n';
    const char csvSplitter = ',';
    const int minInfo = 2;


    #region Singleton
    public static Server Instance {
        get {
            if (m_Instance == null) {
                m_Instance = new Server();
            }
            return m_Instance;
        }
    }

    #endregion
    private Server() {
        this.set = new SettingsWindowViewModel(ApplicationSettingsModel.Instance);
    }

    public void Start() {
        if (running) { //the server can run only one at a time
            return;
        } else {
            running = true;
        }
        this.serv = new TcpListener(IPAddress.Parse(this.set.FlightServerIP), this.set.FlightInfoPort);
        this.serv.Start();
        TcpClient client = this.serv.AcceptTcpClient();

        StatusViewModel.Instance.ServerStatus = true;
        NetworkStream ns = client.GetStream();

        while (client.Connected && !needStop)  //while the client is connected, we look for incoming messages
        {

            byte[] msg = new byte[bufferSize];
            try {
                if (ns.Read(msg, 0, msg.Length) == 0) {
                    break; //if we done to read
                }
            } catch (System.IO.IOException) {
                //will happend when connection lost.
                continue;
            }
            string strMsg = Encoding.Default.GetString(msg);
            strMsg = strMsg.Split(msgSplitter)[0].Trim(); //in a case of a couple of messages

            string[] words = strMsg.Split(csvSplitter);

            if (words.Length < minInfo) {
                continue;
            }
            //send the 2 firsts infomation
            PropertyChange(this, new PropertyChangedEventArgs(words[0].ToString() + csvSplitter + words[1].ToString()));
        }
        //set the server status to false, and close the connection
        StatusViewModel.Instance.ServerStatus = false;
        client.Close();
        this.serv.Stop();
        running = false;
        needStop = false;
    }

    public void Stop() {
        if (!running) return;
        needStop = true;
    }

}