using System;
using System.Text;
using System.Windows.Forms;
using Client.Controller;

namespace Client.View
{
    delegate void Refresh();
    public partial class Client : Form
    {
        public int competitorID { get; set; }
        public string competitor { get; set; }

        ChessController chesscontrol = new ChessController();
        public int player = 1;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            chesscontrol.Initilaze();
            prgbTime.ForeColor = System.Drawing.Color.Blue;
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            chesscontrol.ShowChessBoard(e.Graphics);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            prgbTime.Value = 0;
            lblTime.Text = "0";
            //View.Menu.Client.Send(Encoding.Unicode.GetBytes("PlayerPlay`" + competitorID + "`" + e.X + "`" + e.Y));
            bool end = chesscontrol.PlayerPress(ref player, e.X, e.Y);
            pictureBox1.Refresh();
            if (end)
            {
                timer1.Stop();
                MessageBox.Show(player.ToString() + " Win!");
            }
        }

        public void ReceiveData(int x, int y)
        {
            bool end = chesscontrol.PlayerPress(ref player, x, y);
            RefreshPictureBox();
            if (end)
            {
                MessageBox.Show(player.ToString() + " Win!");
            }
        }

        public void RefreshPictureBox()
        {
            if (pictureBox1.InvokeRequired)
            {
                Invoke(new Refresh(RefreshPictureBox));
            }
            else
                pictureBox1.Refresh();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prgbTime.PerformStep();
            if (prgbTime.Value % 10 == 0)
                lblTime.Text = (prgbTime.Value / 10).ToString();
            if (prgbTime.Value == 600)
            {
                timer1.Stop();
                MessageBox.Show("End time");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
