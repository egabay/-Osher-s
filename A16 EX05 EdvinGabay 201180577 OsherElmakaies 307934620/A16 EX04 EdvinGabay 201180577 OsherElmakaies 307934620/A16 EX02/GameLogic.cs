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

        public GameLogic(int i_BoardSize)
        {
            InitializeBoard(i_BoardSize);
        }

        private void InitializeBoard(int i_BoardSize)
        {
            m_Board = new Board(i_BoardSize);

        }

        /// Updating the GUI With delegate that movement occured 
        public event MovedOccuredDelegate NotifyMovement;

        private void NotifyMovementHandler(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            NotifyMovement(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
        }
        //------------------------------------------------------

        public void Move(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
            m_Board[i_ToRow, i_ToLine] = i_Sign;

            //Checking if table match gui(Delete it after)
            for (int i = 0; i < m_Board.BoardSize; i++)
            {
                for (int j = 0; j < m_Board.BoardSize; j++)
                {
                    Console.Write(m_Board[i, j].ToString() + " |");
                }
                Console.WriteLine();
            }
            // Updtaing Gui
            NotifyMovementHandler(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
            //----------------------------------------------------------
        }

        public bool IsEmptyPlace(int i_ToRow, int i_ToLine)
        {
            bool isEmpty = m_Board[i_ToRow, i_ToLine] == ePlayer.Empty;
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


