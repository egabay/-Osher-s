using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex02_New
{
    public class GameLogic
    {
        Board m_GameBoard;

        public GameLogic(TableLayoutPanel i_Board)
        {
            m_GameBoard = new Board(i_Board);
        }

        public void Move(Button i_From, Button i_To)
        {
            i_To.Text = i_From.Text;
            i_From.Text = string.Empty;
        }

        public void IsEmptyPlace(Button i_From, Button i_To)
        {
            if (i_To.Text == string.Empty)
            {
                Move(i_From, i_To);
            }
            else
            {
                //exception
            }
        }

        public void IsValidMove(Button i_From, Button i_To, ePlayer i_Sign)
        {
            if (i_Sign == ePlayer.O)
            {
                
            }
            
            if (i_To.Text == string.Empty)
            {
                Move(i_From, i_To);
            }
        }




    }
}
