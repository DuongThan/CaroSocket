﻿using System;

namespace Server
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
