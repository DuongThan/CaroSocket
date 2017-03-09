using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace Server
{
    delegate void UpdateLstview(string txt);
    public partial class Server : Form
    {
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private int Port = 888;
        public Socket server;

        int Autoupdate = 0;

        List<List<Location>> LstLocation = new List<List<Location>>();
        List<ClientPlayer> LstPlayer = new List<ClientPlayer>();
        public Server()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            timer1.Start();
            IPEndPoint iep = new IPEndPoint(IP, Port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            LsbConnect.Items.Add("Waiting for connetion...");
            server.Listen(10);
            Thread thr_listener_client = new Thread(ListenerClient);
            thr_listener_client.Start();
        }


        protected bool SaveData(byte[] Data)
        {
            BinaryWriter Writer = null;
            string Name = "book";

            try
            {
                Writer = new BinaryWriter(File.OpenWrite(Name));
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
        public void ListenerClient()
        {
            while (true)
            {
                try
                {
                    Socket client = server.Accept();
                    byte[] bdata = new byte[1024];
                    int rec = client.Receive(bdata);
                    string strrec = Encoding.Unicode.GetString(bdata, 0, rec);
                    string[] arr = strrec.Split('`');
                    if (arr[0] == "ClientConnected")
                    {
                        ClientPlayer player = new ClientPlayer(int.Parse(arr[1]), arr[2], client);
                        LstPlayer.Add(player);
                    }
                    Thread thr_contect_client = new Thread(ContectWithClient);
                    thr_contect_client.Start(client);
                }
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Contect with client
        /// </summary>
        /// <param name="client"></param>
        public void ContectWithClient(object objClient)
        {
            #region chấp nhận kết nối, đưa vào danh sách client
            Socket client = objClient as Socket;
            byte[] bdata = new byte[1024];
            #endregion

            #region Trao đổi dữ liệu với các client
            while (true)
            {
                try
                {
                    bdata = new byte[1024];
                    int rec = client.Receive(bdata);
                    string strrec = Encoding.Unicode.GetString(bdata, 0, rec);
                    string[] arr = strrec.Split('`');
                    if (arr[0] == "ChatAll")
                    {
                        Client_ChatAll(arr[1]);
                    }
                    else if (arr[0] == "PlayerChat")
                    {

                    }
                    else if (arr[0] == "PlayerPlay")
                    {
                        Client_PlayersPlay(int.Parse(arr[1]), arr[2], arr[3]);
                    }
                    else if (arr[0] == "Challange")
                    {
                        Client_Challange(int.Parse(arr[1]), arr[2], int.Parse(arr[3]));
                    }
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
            #endregion
        }


        /// <summary>
        ///  live players are playing
        /// </summary>
        /// <param name="broad"></param>
        public void View_Live(int broad)
        {
            LstLocation[broad].ForEach(x =>
            {

            });
        }


        public void Client_ChatAll(string data)
        {
            foreach (ClientPlayer player in LstPlayer)
            {
                player.Client.Send(Encoding.Unicode.GetBytes("ChatAll`" + data));
            }
        }

        public void Client_PlayersChat(int competitorID, string content)
        {

        }

        public void Client_PlayersPlay(int competitorID, string x, string y)
        {
            int length = LstPlayer.Count;
            for (int i = 0; i < length; i++)
            {
                if (LstPlayer[i].ClientPlayerID == competitorID)
                {
                    LstPlayer[i].Client.Send(Encoding.Unicode.GetBytes("PlayerPlay`" + x + "`" + y));
                }
            }
        }

        public void Client_Challange(int id, string name, int posCompetitor)
        {
            ClientPlayer player = LstPlayer.Find(x => x.ClientPlayerID == id);
            ClientPlayer Competitor = LstPlayer.Find(x => x.ClientPlayerID == posCompetitor);
            Competitor.Client.Send(Encoding.Unicode.GetBytes("Challange`" + player.ClientPlayerID + "`" + player.Name));
        }

        public void UpdataListview(string text)
        {
            if (LsbConnect.InvokeRequired)
            {
                Invoke(new UpdateLstview(UpdataListview), new object[] { text });
            }
            else
            {
                LsbConnect.Items.Add(text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int length = LstPlayer.Count;
            if (length == 0 || length == Autoupdate) return;
            else
            {
                string nameplayer = "";
                for (int i = 0; i < length; i++)
                {
                    nameplayer += LstPlayer[i].ClientPlayerID + "." + LstPlayer[i].Name + "`";
                }
                nameplayer = nameplayer.Remove(nameplayer.Length - 1);
                for (int i = 0; i < length; i++)
                {
                    LstPlayer[i].Client.Send(Encoding.Unicode.GetBytes("AutoUpdateOnline`" + nameplayer));
                }
                Autoupdate = length;
            }
        }
    }
}
