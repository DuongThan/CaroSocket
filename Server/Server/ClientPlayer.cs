using System.Net.Sockets;

namespace Server
{
    public class ClientPlayer
    {
        public int ClientPlayerID { get; set; }
        public string Name { get; set; }
        public Socket Client { get; set; }
        public ClientPlayer() { }
        public ClientPlayer(int id, string name,Socket socket)
        {
            this.ClientPlayerID = id;
            this.Name = name;
            this.Client = socket;
        }
    }
}
