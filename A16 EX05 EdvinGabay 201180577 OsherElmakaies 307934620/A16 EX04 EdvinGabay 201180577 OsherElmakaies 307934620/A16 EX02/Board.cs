﻿
using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;
using System.Windows.Forms;


namespace Ex02_New
{
    public enum ePlayer
    {
        Empty,
        O,
        U,
        X,
        K,
    };

    public enum eMoveDirection
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
    };

    public enum eMoveType
    {
        None,
        Move,
        Eat,
    }

    public class Board
    {
        private int m_NumberOfK = 0;
        private int m_NumberOfU = 0;

        private Coin[,] m_GameBoard;
        private int m_NumberOfX = 0;
        private int m_NumberOfO = 0;
        private int m_BoardSize;


        public ePlayer this[int i_RowIndex, int i_LineIndex]
        {
            get { return m_GameBoard[i_RowIndex, i_LineIndex].PlayerCoin; }
            set { m_GameBoard[i_RowIndex, i_LineIndex].PlayerCoin = value; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public int NumberOfK
        {
            get { return m_NumberOfK; }
        }

        public int NumberOfU
        {
            get { return m_NumberOfU; }
        }


        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_GameBoard = new Coin[m_BoardSize, m_BoardSize];
        }

        public int NumberOfX
        {
            get { return m_NumberOfX; }
        }

        public int NumberOfO
        {
            get { return m_NumberOfO; }
        }

        private void BoardInitialize(int i_GameBoardSize)
        {
            for (int i = 0; i < i_GameBoardSize / 2 - 1; i++)
            {
                for (int j = 0; j < i_GameBoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        m_GameBoard[i, j] = new Coin(ePlayer.O);
                        j++;
                    }
                    else
                    {
                        j++;
                        m_GameBoard[i, j] = new Coin(ePlayer.O);
                    }
                    m_NumberOfO++;
                }
            }

            for (int i = i_GameBoardSize - 1; i > i_GameBoardSize / 2; i--)
            {
                for (int j = 0; j < i_GameBoardSize; j++)
                {
                    if (i % 2 == 1)
                    {
                        m_GameBoard[i, j] = new Coin(ePlayer.X);
                        j++;
                    }
                    else
                    {
                        j++;
                        m_GameBoard[i, j] = new Coin(ePlayer.X);
                    }
                    m_NumberOfX++;
                }
            }
        }
    }
}



