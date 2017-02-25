using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Socket Client { get; set; }

        public Player() { }
        public Player(int id,string name,Socket socket)
        {
            this.PlayerID = id;
            this.Name = name;
            this.Client = socket;
        }
    }
}
