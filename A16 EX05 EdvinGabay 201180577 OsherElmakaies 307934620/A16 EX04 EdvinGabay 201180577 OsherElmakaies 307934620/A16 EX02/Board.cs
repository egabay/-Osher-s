﻿
using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;


namespace Ex02_Baord
{
    public enum ePlayer
    {
        Empty,
        O,
        U,
        X,
        K,
    };

    // $G$ CSS-999 (-5) Every Class/Enum which is not nested should be in a separate file.
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
        public const int k_SmallLetterToInt = 97;
        public const int k_BigLetterToInt = 65;
        public const int k_RegularMoveSteps = 1;
        public const int k_EatMoveSteps = 2;
        public int sizeOfTable;
        private int m_NumberOfK = 0;
        private int m_NumberOfU = 0;

        protected internal ePlayer[,] m_TableMatrix;
        private int m_NumberOfX = 0;
        private int m_NumberOfO = 0;

        public int NumberOfK
        {
            get { return m_NumberOfK; }
        }

        public int NumberOfU
        {
            get { return m_NumberOfU; }
        }

        public Board(int i_TableSize)
        {
            m_TableMatrix = new ePlayer[i_TableSize, i_TableSize];
            sizeOfTable = i_TableSize;
        }

        public int NumberOfX
        {
            get { return m_NumberOfX; }
        }

        public int NumberOfO
        {
            get { return m_NumberOfO; }
        }

        public void ConvertToIndexNumbers(string i_MoveFromTo, out int o_MoveFromLineIndex, out int o_MoveFromRowIndex,
            out int o_MoveToLineIndex, out int o_MoveToRowIndex)
        {
            string[] splittedMovementData = i_MoveFromTo.Split('>');
            o_MoveFromLineIndex = (int)splittedMovementData[0][0] - k_BigLetterToInt;
            o_MoveFromRowIndex = (int)splittedMovementData[0][1] - k_SmallLetterToInt;
            o_MoveToLineIndex = (int)splittedMovementData[1][0] - k_BigLetterToInt;
            o_MoveToRowIndex = (int)splittedMovementData[1][1] - k_SmallLetterToInt;
        }

        public ePlayer this[int i_RowIndex, int i_LineIndex]
        {
            get { return m_TableMatrix[i_RowIndex, i_LineIndex]; }
        }

        public void InitializeTable()
        {
            for (int i = 0; i < m_TableMatrix.GetLength(0) / 2 - 1; i++)
            {
                for (int j = 0; j < m_TableMatrix.GetLength(1); j++)
                {
                    if (i % 2 == 1)
                    {
                        m_TableMatrix[i, j] = ePlayer.O;
                        j++;
                    }
                    else
                    {
                        j++;
                        m_TableMatrix[i, j] = ePlayer.O;
                    }
                    m_NumberOfO++;
                }
            }
            for (int i = m_TableMatrix.GetLength(0) - 1; i > m_TableMatrix.GetLength(0) / 2; i--)
            {
                for (int j = 0; j < m_TableMatrix.GetLength(1); j++)
                {
                    if (i % 2 == 1)
                    {
                        m_TableMatrix[i, j] = ePlayer.X;
                        j++;
                    }
                    else
                    {
                        j++;
                        m_TableMatrix[i, j] = ePlayer.X;
                    }
                    m_NumberOfX++;
                }
            }
        }

        public string ConvertToString(int i_MoveFromRowIndex, int i_MoveToRowIndex, int i_MoveFromLineIndex,
            int i_MoveToLineIndex, string[] o_ArrayOfEatingPossitions, int i_indexForArray)
        {
            char fromLocationBigLetter = (char)(i_MoveFromLineIndex + k_BigLetterToInt);
            o_ArrayOfEatingPossitions[i_indexForArray] = fromLocationBigLetter.ToString();
            char fromLocationSmallLetter = (char)(i_MoveFromRowIndex + k_SmallLetterToInt);
            o_ArrayOfEatingPossitions[i_indexForArray] += fromLocationSmallLetter.ToString();
            o_ArrayOfEatingPossitions[i_indexForArray] += ">";
            char toLocationBigLetter = (char)(i_MoveToLineIndex + k_BigLetterToInt);
            o_ArrayOfEatingPossitions[i_indexForArray] += toLocationBigLetter.ToString();
            char toLocationSmallLetter = (char)(i_MoveToRowIndex + k_SmallLetterToInt);
            o_ArrayOfEatingPossitions[i_indexForArray] += toLocationSmallLetter.ToString();
            return o_ArrayOfEatingPossitions[i_indexForArray];
        }


    }
}

