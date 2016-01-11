using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex02_New
{
    //public struct StamStruct
    //{
    //    public int FromX;
    //    public int FromY;
    //    public int ToX;
    //    public int ToY;
    //}
    public class GameLogic
    {
        //public List<StamStruct> stam = new List<StamStruct>();
        Board m_Board;
        public const int k_RegularMoveSteps = 1;
        public const int k_EatMoveSteps = 2;

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

        public bool IsEmptyPlace(int i_ToRow, int i_ToLine)
        {
            bool isEmpty = m_Board[i_ToRow, i_ToLine] == ePlayer.Empty;
            return isEmpty;
        }

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

        public bool IsValidMove(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
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

        public void Eat(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
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

        public bool IsValidEat(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            bool isValid = false;
            if (i_Sign == ePlayer.O)
            {
                if (i_FromRow == i_ToRow - 2 && (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    //if bottom right is empty and you eat your opponent
                    if (i_ToLine - 2 == i_FromRow)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow - 1, i_ToLine - 1] == ePlayer.X ||
                             m_Board[i_ToRow - 1, i_ToLine - 1] == ePlayer.K))
                        {
                            isValid = true;
                        }
                    }
                    //if bottom left is empty and you eat your opponent
                    else
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow - 1, i_ToLine + 1] == ePlayer.X ||
                             m_Board[i_ToRow - 1, i_ToLine + 1] == ePlayer.K))
                        {
                            isValid = true;
                        }
                    }
                }
            }
            else if (i_Sign == ePlayer.X)
            {
                if (i_FromRow == i_ToRow + 2 && (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    //if up right is empty and you eat your opponent
                    if (i_ToLine - 2 == i_FromRow)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.O ||
                             m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.U))
                        {
                            isValid = true;
                        }
                    }
                    //if up left is empty and you eat your opponent
                    else
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.O ||
                             m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.U))
                        {
                            isValid = true;
                        }
                    }
                }
            }
            else if (i_Sign == ePlayer.U || i_Sign == ePlayer.K)
            {
                if ((i_FromRow == i_ToRow + 2 || i_FromRow == i_ToRow - 2) &&
                    (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    if (i_Sign == ePlayer.U)
                    {
                        //if bottom right
                        if (i_ToLine - 2 == i_FromRow)
                        {
                            if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                                (m_Board[i_ToRow - 1, i_ToLine - 1] == ePlayer.X ||
                                 m_Board[i_ToRow - 1, i_ToLine - 1] == ePlayer.K))
                            {
                                isValid = true;
                            }
                        }
                        //if bottom left
                        else
                        {
                            if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                                (m_Board[i_ToRow - 1, i_ToLine + 1] == ePlayer.X ||
                                 m_Board[i_ToRow - 1, i_ToLine + 1] == ePlayer.K))
                            {
                                isValid = true;
                            }
                        }
                    }
                    else
                    {
                        //if up right
                        if (i_ToLine - 2 == i_FromRow)
                        {
                            if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                                (m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.O ||
                                 m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.U))
                            {
                                isValid = true;
                            }
                        }
                        //if up left
                        else
                        {
                            if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                                (m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.O ||
                                 m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.U))
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }
            return isValid;
        }

        public void CheckWhichMoveIsIt(int i_FromRow, int i_ToRow, int i_FromLine,
            int i_ToLine, ePlayer i_Sign, bool i_CanEatAgainStatus)
        {
            //eMoveType retVal = eMoveType.None;
            //if (i_CanEatAgainStatus)
            //{
            //    Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
            //    //retVal = eMoveType.Eat;
            //}
            //else
            {
                switch (i_Sign)
                {
                    case ePlayer.X:
                    {
                        if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                        {
                            Move(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            //retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                //retVal = eMoveType.Eat;
                            }
                        }
                        break;
                    }
                    case ePlayer.O:
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                        {
                            Move(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            //retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                //retVal = eMoveType.Eat;
                            }
                        }
                        break;
                    }
                    case ePlayer.K:
                    case ePlayer.U:
                    {
                        if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine,
                            i_ToLine,
                            k_RegularMoveSteps))
                        {
                            Move(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            //retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine,
                                i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                //retVal = eMoveType.Eat;
                            }
                            else
                            {
                                if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine,
                                    i_ToLine, k_RegularMoveSteps))
                                {
                                    Move(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                    //retVal = eMoveType.Move;
                                }
                                else
                                {
                                    if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine,
                                        i_ToLine, k_EatMoveSteps))
                                    {
                                        Eat(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                        //retVal = eMoveType.Eat;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        public bool IsODirectionMove(int i_FromRow, int i_ToRow, int i_FromLine,
            int i_ToLine, int i_StepsToMove)
        {
            const bool v_isODirectionRegularMove = true;
            bool retVal = !v_isODirectionRegularMove;

            if ((i_FromRow + i_StepsToMove == i_ToRow &&
                 (i_FromLine == i_ToLine - i_StepsToMove ||
                  i_FromLine == i_ToLine + i_StepsToMove)))
            {
                retVal = v_isODirectionRegularMove;
            }
            return retVal;
        }

        public bool IsXDirectionMove(int i_FromRow, int i_ToRow, int i_FromLine,
            int i_ToLine, int i_StepsToMove)
        {
            const bool v_isXDirectionRegularMove = true;
            bool retVal = !v_isXDirectionRegularMove;

            if ((i_FromRow == i_ToRow + i_StepsToMove &&
                 (i_FromLine == i_ToLine - i_StepsToMove ||
                  i_FromLine == i_ToLine + i_StepsToMove)))
            {
                retVal = v_isXDirectionRegularMove;
            }
            return retVal;
        }

        public bool CheckForEatingMovesFirst(ePlayer i_EPlayerSign, out int[] o_ArrayOfEatingPossitions)
        {
            //StamStruct shuki = new StamStruct();
            //stam.Add(new StamStruct());
            int indexForArray = 0;
            bool isEatingMoves = false;
            o_ArrayOfEatingPossitions = new int[m_Board.BoardSize*4];
            for (int indexFromRow = 0; indexFromRow < m_Board.BoardSize; indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < m_Board.BoardSize; indexFromLine++)
                {
                    if (m_Board[indexFromRow, indexFromLine] == i_EPlayerSign)
                    {
                        if (i_EPlayerSign == ePlayer.X)
                        {
                            int indexToRow = indexFromRow - 2;
                            int indexToTopLeftLine = indexFromLine - 2;
                            int indexToTopRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToTopLeftLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopRightLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToTopRightLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                        }
                        else if (i_EPlayerSign == ePlayer.O)
                        {
                            int indexToRow = indexFromRow + 2;
                            int indexToBottomLeftLine = indexFromLine - 2;
                            int indexToBottomRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow,
                                    indexToBottomLeftLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToBottomLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToBottomLeftLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow,
                                    indexToBottomRightLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow,
                                    indexToBottomRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToBottomRightLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                        }
                        else if (i_EPlayerSign == ePlayer.K || i_EPlayerSign == ePlayer.U)
                        {
                            int indexToUpRow = indexFromRow + 2;
                            int indexToTopLeftLine = indexFromLine - 2;
                            int indexToTopRightLine = indexFromLine + 2;
                            int indexToDownRow = indexFromRow - 2;
                            int indexToBottomLeftLine = indexFromLine - 2;
                            int indexToBottomRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomLeftLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToUpRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToBottomLeftLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomRightLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToUpRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToBottomRightLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopRightLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToDownRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToTopRightLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                            if (
                                IsValidMove(i_EPlayerSign, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopLeftLine) &&
                                IsValidEat(i_EPlayerSign, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = indexFromRow;
                                o_ArrayOfEatingPossitions[indexForArray + 1] = indexFromLine;
                                o_ArrayOfEatingPossitions[indexForArray + 2] = indexToDownRow;
                                o_ArrayOfEatingPossitions[indexForArray + 3] = indexToTopLeftLine;
                                //Eat(i_EPlayerSign, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine);
                                isEatingMoves = true;
                                indexForArray += 4;
                            }
                        }
                    }
                }
            }
            return isEatingMoves;
        }

        //if yes, perform eat after that method
        public bool IsChoosedEatingFirst(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine,
            int[] i_ArrayOfEatingPossitions)
        {
            bool isChooshed = false;
            for (int i = 0; i < i_ArrayOfEatingPossitions.Length; i += 4)
            {
                if (i_FromRow == i_ArrayOfEatingPossitions[i] && i_FromLine == i_ArrayOfEatingPossitions[i + 1] &&
                    i_ToRow == i_ArrayOfEatingPossitions[i + 2] && i_ToLine == i_ArrayOfEatingPossitions[i + 3])
                {
                    isChooshed = true;
                    break;
                }
            }
            return isChooshed;
        }
    }
}


