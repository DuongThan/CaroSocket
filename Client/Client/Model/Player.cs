using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
   [Serializable()]
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public Player(int id, string name)
        {
            this.PlayerID = id;
            this.Name = name;
        }
    }
}
