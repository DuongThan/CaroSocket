using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.View;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace Client.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtID.Text == "") return;
            else
            {
                Menu menu = new Menu();
                menu.PlayerID = int.Parse(txtID.Text);
                menu.UserName = txtUserName.Text;
                menu.StartPosition = FormStartPosition.CenterScreen;
                menu.FormClosed += Menu_FormClosed;
                this.Hide();
                menu.Show();
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
