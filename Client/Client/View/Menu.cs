using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Client.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client.View
{
    delegate void UpdateData(string txt);
    delegate void Clear();
    delegate void ShowForm(int id, string name);
    public partial class Menu : Form
    {
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private int Port = 888;

        public int PlayerID { get; set; }
        public string UserName { get; set; }
        public static Socket Client;
        private List<Player> Lstplayer = new List<Player>();
        private Client clientplay;
        public Menu()
        {
            InitializeComponent();
            PlayerID = 1;
        }

        #region Serialize Deserialize
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        #endregion

        private void Menu_Load(object sender, EventArgs e)
        {
            IPEndPoint iep = new IPEndPoint(IP, Port);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client.Connect(iep);
            string dataSend = "ClientConnected`" + PlayerID + "`" + UserName;
            Client.Send(Encoding.Unicode.GetBytes(dataSend));
            Thread thread = new Thread(Contect_Server);
            thread.Start();

            clientplay = new Client();
            this.Text = "Hello " + UserName;
        }

        public void Contect_Server()
        {
            while (true)
            {
                byte[] data = new byte[1024];
                int rec = Client.Receive(data);
                string command = Encoding.Unicode.GetString(data, 0, rec);
                string[] arr = command.Split('`');
                if (arr[0] == "AutoUpdateOnline")
                {
                    ClearLstOnline();
                    Lstplayer.Clear();
                    for (int i = 1; i < arr.Length; i++)
                    {
                        UpdateLstonline(arr[i].ToString().Split('.')[1]);
                        Lstplayer.Add(new Player(int.Parse(arr[i].ToString().Split('.')[0]), arr[i].ToString().Split('.')[1]));
                    }
                }
                else if (arr[0] == "ChatAll")
                {
                    UpdateListBox(arr[1]);
                }
                else if (arr[0] == "PlayerPlay")
                {
                    int x = int.Parse(arr[1]);
                    int y = int.Parse(arr[2]);
                    clientplay.ReceiveData(x, y);
                }
                else if (arr[0] == "Challange")
                {
                    Thread thread2 = new Thread(Challange);
                    object[] obj = { int.Parse(arr[1]), arr[2] };
                    thread2.Start(obj);
                }
            }
        }

        public void ClearLstOnline()
        {
            if (lsbOnline.InvokeRequired)
            {
                Invoke(new Clear(ClearLstOnline));
            }
            else
                lsbOnline.Items.Clear();
        }
        public void UpdateLstonline(string Name)
        {
            if (lsbOnline.InvokeRequired)
            {
                Invoke(new UpdateData(UpdateLstonline), new object[] { Name });
            }
            else
                lsbOnline.Items.Add(Name);
        }
        public void UpdateListBox(string data)
        {
            if (rtbBroad.InvokeRequired)
            {
                Invoke(new UpdateData(UpdateListBox), new object[] { data });
            }
            else
                rtbBroad.Text += "\n" + data;
        }

        public void Challange(object obj)
        {
            object[] obj1 = obj as object[];
            int id = (int)obj1[0];
            string name = (string)obj1[1];
            if (MessageBox.Show(UserName + " send this challange to "+name) == DialogResult.OK)
            {
                ShowFormClient(id, name);
            }
        }

        public void ShowFormClient(int id, string name)
        {
            if (rtbBroad.InvokeRequired)
            {
                Invoke(new ShowForm(ShowFormClient), new object[] { id, name });
            }
            else
            {
                clientplay.competitorID = id;
                clientplay.competitor = name;
                clientplay.StartPosition = FormStartPosition.CenterScreen;
                clientplay.FormClosed += Clientplay_FormClosed;
                clientplay.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtchat.Text == "") return;
            string dataSend = "ChatAll`" + txtchat.Text;
            Client.Send(Encoding.Unicode.GetBytes(dataSend));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lsbOnline.SelectedItem == null)
                e.Cancel = true;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (lsbLive.SelectedItem == null)
                e.Cancel = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lsbOnline.SelectedItem == null) return;
            Client.Send(Encoding.Unicode.GetBytes("Challange`" + PlayerID + "`" + UserName + "`" + Lstplayer[lsbOnline.SelectedIndex].PlayerID));
            clientplay.competitorID = Lstplayer[lsbOnline.SelectedIndex].PlayerID;
            clientplay.competitor = Lstplayer[lsbOnline.SelectedIndex].Name;
            clientplay.StartPosition = FormStartPosition.CenterScreen;
            clientplay.FormClosed += Clientplay_FormClosed;
            clientplay.Show();
        }

        private void Clientplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            clientplay = new View.Client();
        }
    }
}

