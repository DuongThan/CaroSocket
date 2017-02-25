using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View
{
    delegate void UpdateData(string txt);
    public partial class Menu : Form
    {
        public static Socket client;
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private int Port = 888;
        private TcpClient tcpCli = new TcpClient();


        public string UserName { get; set; }
        Stream stream;
        StreamWriter write;
        StreamReader read;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            tcpCli.Connect(IP, Port);
            stream = tcpCli.GetStream();
            write = new StreamWriter(stream);
            read = new StreamReader(stream);
            Thread thread = new Thread(Contect_Server);
            thread.Start();
        }

        public void Contect_Server()
        {
            write.AutoFlush = true;
            write.WriteLine("1."+UserName);
            while (true)
            {
                try
                {
                    string data = read.ReadLine();
                    UpdateListBox(data);
                }
                catch { /*break; */}
            }
            client.Close();
        }

        public void UpdateListBox(string data)
        {
            if (rtbBroad.InvokeRequired)
            {
                Invoke(new UpdateData(UpdateListBox), new object[] { data });
            }
            else
                rtbBroad.Text += data + "\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Client clientplay = new Client();
            clientplay.StartPosition = FormStartPosition.CenterScreen;
            clientplay.FormClosed += Clientplay_FormClosed;
            this.Hide();
            clientplay.Show();
        }

        private void Clientplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            write.WriteLine("chatAll." + textBox1.Text);
        }
    }
}
