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
        public event NotifyEatingOccuredDelegate NotifyEat;
        private void NotifyMovementHandler(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            NotifyMovement(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
        }
        private void NotifyOnEatOccured(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow,int i_EatenLine,int i_EatenRow)
        {
            NotifyEat( i_FromLine,  i_FromRow,  i_ToLine,  i_ToRow, i_EatenLine, i_EatenRow);
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

            //Checking if table match gui(Delete it after) 3 = X / 1 = O
            for (int i = 0; i < m_Board.BoardSize; i++)
            {
                for (int j = 0; j < m_Board.BoardSize; j++)
                {
                    Console.Write(Convert.ToInt32(m_Board[i, j]) + " |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("======================================================");
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
                //Updating UI
                NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_FromLine + 1, i_FromRow + 1);
            }
            else if (i_ToLine < i_FromLine && i_ToRow > i_FromRow)
            {
                //bottom left
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine - 1, i_FromRow + 1] = ePlayer.Empty;
                m_Board[i_FromLine - 2, i_FromRow + 2] = i_Sign;
                NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_FromLine - 1, i_FromRow + 1);
            }

            else if (i_ToLine < i_FromLine && i_ToRow < i_FromRow)
            {
                //up right
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine + 1, i_FromRow - 1] = ePlayer.Empty;
                m_Board[i_FromLine + 2, i_FromRow - 2] = i_Sign;
                NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_FromLine + 1, i_FromRow - 1);
            }
            else if (i_ToLine > i_FromLine && i_ToRow < i_FromRow)
            {
                //up left
                m_Board[i_FromLine, i_FromRow] = ePlayer.Empty;
                m_Board[i_FromLine - 1, i_FromRow - 1] = ePlayer.Empty;
                m_Board[i_FromLine - 2, i_FromRow - 2] = i_Sign;
                NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_FromLine - 1, i_FromRow - 1);
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
            if (i_CanEatAgainStatus)
            {
                Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
                //retVal = eMoveType.Eat;
            }
            else
            {
                switch (i_Sign)
                {
                    case ePlayer.X:
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
                                Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
                                //retVal = eMoveType.Eat;
                            }
                        }
                        break;
                    }
                    case ePlayer.O:
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine,
                            i_ToLine,
                            k_RegularMoveSteps))
                        {
                            Move(i_Sign, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            //retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine,
                                i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
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
                                Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
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
                                        Eat(i_Sign, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
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

        //public bool CheckForEatingMovesFirst(ePlayer i_EPlayerSign, out string[] o_ArrayOfEatingPossitions)
        //{
        //    int indexForArray = 0;
        //    bool isEatingMoves = false;
        //    o_ArrayOfEatingPossitions = new string[16];
        //    for (int indexFromRow = 0; indexFromRow < m_Board.BoardSize; indexFromRow++)
        //    {
        //        for (int indexFromLine = 0; indexFromLine < m_Board.BoardSize; indexFromLine++)
        //        {
        //            if (m_Board[indexFromRow, indexFromLine] == i_EPlayerSign)
        //            {
        //                if (i_EPlayerSign == ePlayer.X)
        //                {
        //                    int indexToRow = indexFromRow - 2;
        //                    int indexToTopLeftLine = indexFromLine - 2;
        //                    int indexToTopRightLine = indexFromLine + 2;
        //                    if (IsValidMove(i_EPlayerSign, indexFromLine, indexFromRow, indexToTopLeftLine, indexToRow) && IsValidEat(i_EPlayerSign, indexFromLine, indexFromRow, indexToTopLeftLine, indexToRow))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
        //                            indexFromLine, indexToTopLeftLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToRow) &&
        //                        IsEatable(eMoveDirection.TopRight, i_EPlayerSign, indexToRow, indexToTopRightLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
        //                            indexFromLine, indexToTopRightLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                }
        //                else if (i_EPlayerSign == ePlayer.O)
        //                {
        //                    int indexToRow = indexFromRow + 2;
        //                    int indexToBottomLeftLine = indexFromLine - 2;
        //                    int indexToBottomRightLine = indexFromLine + 2;
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToRow) &&
        //                        IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, indexToRow, indexToBottomLeftLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
        //                            indexFromLine, indexToBottomLeftLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToRow) &&
        //                        IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, indexToRow, indexToBottomRightLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
        //                            indexFromLine, indexToBottomRightLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                }
        //                else if (i_EPlayerSign == ePlayer.K || i_EPlayerSign == ePlayer.U)
        //                {
        //                    int indexToUpRow = indexFromRow + 2;
        //                    int indexToTopLeftLine = indexFromLine - 2;
        //                    int indexToTopRightLine = indexFromLine + 2;
        //                    int indexToDownRow = indexFromRow - 2;
        //                    int indexToBottomLeftLine = indexFromLine - 2;
        //                    int indexToBottomRightLine = indexFromLine + 2;
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToUpRow) &&
        //                        IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, indexToUpRow,
        //                            indexToBottomLeftLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
        //                            indexFromLine, indexToBottomLeftLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToUpRow) &&
        //                        IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, indexToUpRow,
        //                            indexToBottomRightLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
        //                            indexFromLine, indexToBottomRightLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToTopLeftLine, indexToDownRow) &&
        //                        IsEatable(eMoveDirection.TopLeft, i_EPlayerSign, indexToDownRow, indexToTopLeftLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
        //                            indexFromLine, indexToTopLeftLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                    if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToDownRow) &&
        //                        IsEatable(eMoveDirection.TopRight, i_EPlayerSign, indexToDownRow, indexToTopRightLine))
        //                    {
        //                        o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
        //                            indexFromLine, indexToTopRightLine,
        //                            o_ArrayOfEatingPossitions, indexForArray);
        //                        isEatingMoves = true;
        //                        indexForArray++;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return isEatingMoves;
        //}
    }
}


