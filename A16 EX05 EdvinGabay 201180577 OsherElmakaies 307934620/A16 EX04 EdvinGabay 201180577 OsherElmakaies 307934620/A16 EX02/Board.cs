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

        private ePlayer[,] m_TableMatrix;
        private int m_NumberOfX = 0;
        private int m_NumberOfO = 0;
        private int m_BoardSize;
        public TableLayoutPanel m_Board;

        public int NumberOfK
        {
            get { return m_NumberOfK; }
        }

        public int NumberOfU
        {
            get { return m_NumberOfU; }
        }

        public Board(TableLayoutPanel i_Board)
        {
            m_Board = i_Board;
        }

        public int NumberOfX
        {
            get { return m_NumberOfX; }
        }

        public int NumberOfO
        {
            get { return m_NumberOfO; }
        }
    }
}

