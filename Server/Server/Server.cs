using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Server
{
    delegate void UpdateLstview(string txt);
    public partial class Server : Form
    {
        List<List<Location>> LstLocation = new List<List<Location>>();
        List<Player> LstPlayer = new List<Player>();
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private int Port = 888;
        private TcpListener tcpLi = null;
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
            tcpLi = new TcpListener(IP, Port);
            tcpLi.Start();
            LsbConnect.Items.Add("Waiting for connetion...");
            Thread thr_listener_client = new Thread(ListenerClient);
            thr_listener_client.Start();
        }

        public void ListenerClient()
        {
            while (true)
            {
                try
                {
                    Socket client = tcpLi.AcceptSocket();
                    Thread thr_contect_client = new Thread(ContectWithClient);
                    thr_contect_client.Start(client);
                }
                catch
                {
                    break;
                }
            }
            tcpLi.Stop();
        }

        /// <summary>
        /// Contect with client
        /// </summary>
        /// <param name="client"></param>
        public void ContectWithClient(object objClient)
        {
            #region chấp nhận kết nối, đưa vào danh sách client
            Socket client = objClient as Socket;
            Stream stream = new NetworkStream(client);
            StreamReader read = new StreamReader(stream);
            string data = read.ReadLine();
            int ID = int.Parse(data.Substring(0, data.IndexOf(".")));
            string Name = data.Substring(data.IndexOf(".") + 1, data.Length - 1- ID.ToString().Length);
            Player player = new Player(ID, Name, client);
            LstPlayer.Add(player);
            Client_Connected();
            #endregion

            #region Trao đổi dữ liệu với các client
            while (true)
            {
                data = read.ReadLine();
                if (data != null)
                {
                    int lc = data.IndexOf('.'); // use to check type of data, chat or play with another player
                    string str_check_curentType = data.Substring(0, data.IndexOf('.'));
                    string content = data.Substring(lc + 1, data.Length - 1- str_check_curentType.Length);
                    if (str_check_curentType == "chatAll")
                        Client_ChatAll(content);
                    else if (str_check_curentType == "playChat")
                        Client_PlayersChat(int.Parse(content.Substring(0, content.IndexOf("."))), content.Substring(content.IndexOf(".") + 1, content.Length));
                    else Client_PlayersPlay(int.Parse(content.Substring(0, content.IndexOf("."))), content.Substring(content.IndexOf(".") + 1, content.Length));
                }
            }
            #endregion

            //Kết thúc cuộc trò chuyện
            stream.Close();
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


        public void Client_Connected()
        {

            foreach (Player player in LstPlayer)
            {
                Socket client = player.Client;
                Stream stream = new NetworkStream(client);
                StreamWriter write = new StreamWriter(stream);
                write.AutoFlush = true;
                write.WriteLine(player.Name + " was connected");
                write.Close();
                stream.Close();
            }
        }
        public void Client_ChatAll(string data)
        {
            foreach (Player player in LstPlayer)
            {
                Socket client = player.Client;
                Stream stream = new NetworkStream(client);
                StreamWriter write = new StreamWriter(stream);
                write.AutoFlush = true;
                write.WriteLine(data);
                write.Close();
                stream.Close();
            }
        }

        public void Client_PlayersChat(int competitorID, string content)
        {

        }

        public void Client_PlayersPlay(int competitorID, string data)
        {

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
    }
}
