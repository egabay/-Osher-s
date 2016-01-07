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
        public void Move(Button i_From, Button i_To)
        {     
            i_To.Text = i_From.Text;
            i_From.Text = string.Empty;
           
        }   

        public void IsMoveable(Button i_From,Button i_To)
        {
            if(i_To.Text==string.Empty)
            {
                Move(i_From, i_To);
            }
        }



      
    }
}
