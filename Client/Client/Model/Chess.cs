using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Model
{
    public class Chess
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Point_X { get; set; }
        public int Point_Y { get; set; }

        public int Curent_Type { get; set; }

        public Image Image { get; set; }
        public Chess() { }

        public Chess(int x, int y, int point_x, int point_y, int curent_type)
        {
            this.X = x;
            this.Y = y;
            this.Point_X = point_x;
            this.Point_Y = point_y;
            this.Curent_Type = curent_type;
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(this.Image, this.Point_X+1, this.Point_Y+1,23,23);
        }
    }

}
