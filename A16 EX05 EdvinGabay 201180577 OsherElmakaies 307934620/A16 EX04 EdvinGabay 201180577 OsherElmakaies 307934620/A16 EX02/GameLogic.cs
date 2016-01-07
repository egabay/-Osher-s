using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex02_New
{
    public class GameLogic
    {
        Board m_Board;

        public GameLogic()
        {
            m_Board = new Board(6);
        }
        //Done
        public void Move(ePlayer i_Sign, int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            m_Board[i_FromLine, i_FromRow] = ePlayer.Empty; 
            m_Board[i_ToLine, i_ToRow] = i_Sign;
        }

        public void IsMoveable(Button i_From, Button i_To)
        {
            if (i_To.Text == string.Empty)
            {
                Move(i_From, i_To);
            }
        }
    }
}
