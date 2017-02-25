using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Controller;
using Client.Helper;

namespace Client.View
{
    public partial class Client : Form
    {
        ChessController chesscontrol = new ChessController();
        private int player = 1;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            chesscontrol.Initilaze();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            chesscontrol.ShowChessBoard(e.Graphics);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bool end = chesscontrol.PlayerPress(ref player, e.X, e.Y);
            pictureBox1.Refresh();
            if(end)
            {
                MessageBox.Show(player.ToString() + " Win!");
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
