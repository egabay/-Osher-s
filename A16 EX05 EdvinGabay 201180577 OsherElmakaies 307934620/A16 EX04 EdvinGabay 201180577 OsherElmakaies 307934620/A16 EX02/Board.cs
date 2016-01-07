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
            m_GameBoard = new Coin[i_BoardSize, i_BoardSize];
        }

        public int NumberOfX
        {
            get { return m_NumberOfX; }
        }

        public int NumberOfO
        {
            get { return m_NumberOfO; }
        }

        private BoardInitialize(int i_GameBoardSize)
        {
            for (int i = 0; i < i_GameBoardSize; i++)
			{
			     for (int j = 0; j < i_GameBoardSize; j++)
			    {
			      
			    }
			}
        }

    }
}

