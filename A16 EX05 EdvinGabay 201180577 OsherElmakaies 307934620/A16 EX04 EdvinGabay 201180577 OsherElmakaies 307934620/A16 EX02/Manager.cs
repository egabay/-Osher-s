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

        public Manager(TableLayoutPanel i_Board)
        {
            m_GameBoard = new Board(i_Board);
            m_GameLogic = new GameLogic();
        }

        public void Move()
        {
            Notify();
        }

        public void KingCheck()
        {
        }

        public void ClickPerformed(Button i_ClickedOn)
        {
            Move();
        }

        public event ChangeButtonStatusDelegate NotifyChangeButtonStatus;

        private void Notify()
        {
        }
    }
}
