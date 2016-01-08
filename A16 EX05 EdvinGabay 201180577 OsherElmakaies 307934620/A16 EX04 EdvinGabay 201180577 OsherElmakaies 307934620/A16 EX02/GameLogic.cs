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

        public void Move(ePlayer i_Sign, int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
            m_Board[i_ToLine, i_ToRow] = i_Sign;
        }

        public bool IsEmptyPlace(int i_ToLine, int i_ToRow)
        {
            bool isEmpty = m_Board[i_ToLine, i_ToRow] == ePlayer.Empty;
            return isEmpty;
        }

        public bool IsValidMove(ePlayer i_Sign, int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            bool isValid = false;
            if (i_Sign == ePlayer.O)
            {
                if (i_FromRow == i_ToRow - 1 && (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                {
                    isValid = true;
                }
            }
            else if (i_Sign == ePlayer.X)
            {
                if (i_FromRow == i_ToRow + 1 && (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                {
                    isValid = true;
                }
            }
            else if (i_Sign == ePlayer.U || i_Sign == ePlayer.K)
            {
                if ((i_FromRow == i_ToRow + 1 || i_FromRow == i_ToRow - 1) &&
                    (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public void Eat(ePlayer i_Sign, int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow)
        {
            if (i_ToLine > i_FromLine && i_ToRow > i_FromRow)
            {
                //bottom right
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine + 1, i_FromRow + 1] = ePlayer.Empty;
                m_Board[i_FromLine + 2, i_FromRow + 2] = i_Sign;
            }
            else if (i_ToLine < i_FromLine && i_ToRow > i_FromRow)
            {
                //bottom left
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine - 1, i_FromRow + 1] = ePlayer.Empty;
                m_Board[i_FromLine - 2, i_FromRow + 2] = i_Sign;
            }

            else if (i_ToLine < i_FromLine && i_ToRow < i_FromRow)
            {
                //up right
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine + 1, i_FromRow - 1] = ePlayer.Empty;
                m_Board[i_FromLine + 2, i_FromRow - 2] = i_Sign;
            }
            else if (i_ToLine > i_FromLine && i_ToRow < i_FromRow)
            {
                //up left
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine - 1, i_FromRow - 1] = ePlayer.Empty;
                m_Board[i_FromLine - 2, i_FromRow - 2] = i_Sign;
            }
        }
    }
}

}
