using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Helper;
using Client.Model;
using System.Threading;

namespace Client.Controller
{
    public class ChessController
    {
        private Chess[,] ChessMatrix;

        private List<Chess> LstLocation;
        public ChessController()
        {
            LstLocation = new List<Chess>();
        }
        public void Initilaze()
        {
            ChessMatrix = new Chess[Const.HEIGHT_BOARD, Const.WIDTH_BOARD];
            for (int i = 0; i < Const.HEIGHT_BOARD; i++)
            {
                for (int j = 0; j < Const.WIDTH_BOARD; j++)
                {
                    Chess chess = new Chess(i, j, j * Const.WIDTH_CHESS, i * Const.HEIGHT_CHESS, 0);
                    ChessMatrix[i, j] = chess;
                }
            }
        }

        public void ShowChessBoard(Graphics gr)
        {
            Pen pen = new Pen(Color.Brown);
            // draw the line column
            for (int i = 0; i <= Const.HEIGHT_BOARD; i++)
            {
                gr.DrawLine(pen, 0, i * Const.HEIGHT_CHESS, Const.WIDTH_BOARD * Const.WIDTH_CHESS, i * Const.HEIGHT_CHESS);
            }
            // draw the line row
            for (int i = 0; i <= Const.WIDTH_BOARD; i++)
            {
                gr.DrawLine(pen, i * Const.WIDTH_CHESS, 0, i * Const.WIDTH_CHESS, Const.HEIGHT_BOARD * Const.HEIGHT_CHESS);
            }
            LstLocation.ForEach(x => x.Draw(gr));
        }
        public bool PlayerPress(ref int player, int point_x, int point_y)
        {
            int x = point_x / Const.WIDTH_CHESS;
            int y = point_y / Const.HEIGHT_CHESS;
            if (x == Const.WIDTH_BOARD || y == Const.HEIGHT_BOARD) return false;
            if (ChessMatrix[y, x].Curent_Type != 0) return false;
            ChessMatrix[y, x].Curent_Type = player;
            ChessMatrix[y, x].Image = Image.FromFile(Application.StartupPath + "/Image/" + player.ToString() + ".jpg");
            LstLocation.Add(ChessMatrix[y, x]);
            if (End(x, y)) return true;
            player = player == 1 ? 2 : 1;
            return false;
        }

        private bool End(int x, int y)
        {
            int count = 1;
            #region Check Row
            int j = x;
            int i = y;
            while (j > 0)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i, j - 1].Curent_Type)
                {
                    count++;
                    j--;
                }
                else
                    break;
            }
            j = x;
            while (j < Const.WIDTH_BOARD - 1)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i, j + 1].Curent_Type)
                {
                    count++;
                    j++;
                }
                else
                    break;
            }
            if (count >= 5) return true;
            else count = 1;
            #endregion

            #region Check Column
            i = y;
            j = x;
            while (i > 0)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i - 1, j].Curent_Type)
                {
                    count++;
                    i--;
                }
                else
                    break;
            }
            i = y;
            while (i < Const.HEIGHT_BOARD - 1)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i + 1, j].Curent_Type)
                {
                    count++;
                    i++;
                }
                else
                    break;
            }
            if (count >= 5) return true;
            else count = 1;
            #endregion

            #region Check Cheo chinh
            i = y;
            j = x;
            while(i>0 && j>0)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i - 1, j - 1].Curent_Type)
                {
                    count++;
                    i--;
                    j--;
                }
                else
                    break;
            }
            i = y;
            j = x;

            while(i<Const.HEIGHT_BOARD-1 && j< Const.WIDTH_BOARD-1)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i + 1, j + 1].Curent_Type)
                {
                    count++;
                    i++;
                    j++;
                }
                else
                    break;
            }
            if (count >= 5) return true;
            else count = 1;
            #endregion

            #region Check Cheo phu
            i = y;
            j = x;
            while(i>0 && j< Const.WIDTH_BOARD-1)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i - 1, j + 1].Curent_Type)
                {
                    count++;
                    i--;
                    j++;
                }
                else
                    break;
            }
            i = y;
            j = x;
            while (i < Const.HEIGHT_BOARD - 1 && j>0)
            {
                if (ChessMatrix[i, j].Curent_Type == ChessMatrix[i + 1, j - 1].Curent_Type)
                {
                    count++;
                    i++;
                    j--;
                }
                else
                    break;
            }
            if (count >= 5) return true;
            else count = 1;
            #endregion
            return false;
        }
    }
}
