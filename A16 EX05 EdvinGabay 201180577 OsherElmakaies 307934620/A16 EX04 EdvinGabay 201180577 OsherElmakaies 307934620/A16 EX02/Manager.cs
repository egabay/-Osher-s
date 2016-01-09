using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{
    class Manager
    {
        Board m_GameBoard;
        GameLogic m_GameLogic;

        public Manager(int i_SizeBoard)
        {
            m_GameBoard = new Board(i_SizeBoard);

        }

        public void Move()
        {
            Notify();
        }

        public void KingCheck()
        {
        }


        public event MovedOccuredDelegate NotifyMovement;

        private void Notify()
        {
        }
    }
}
