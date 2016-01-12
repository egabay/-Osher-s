using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05
{
    public delegate void MovedOccuredDelegate(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow);

    public delegate void NotifyEatingOccuredDelegate(
        int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow, int i_EatenLine, int i_EatenRow);

    public delegate void UpdateInfoFromSettingDialogDelegate(
        int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName);

    public delegate void NotifyInvalidMove(string i_InvalidMoveMsg);

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
        public event NotifyInvalidMove NotifyInvalidMove;

        private void NotifyMovementHandler(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            NotifyMovement(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
        }

        private void NotifyOnEatOccured(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow, int i_EatenLine,
            int i_EatenRow)
        {
            NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_EatenLine, i_EatenRow);
        }

        private void NotifyOnInvalidMove(string i_MsgToNotify)
        {
            NotifyInvalidMove(i_MsgToNotify);
        }

        //------------------------------------------------------

        public bool IsEmptyPlace(int i_ToRow, int i_ToLine)
        {
            bool isEmpty = m_Board[i_ToRow, i_ToLine] == ePlayer.Empty;
            return isEmpty;
        }

        public void Move(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            if (IsValidMove(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine))
            {
                m_Board[i_ToRow, i_ToLine] = m_Board[i_FromRow, i_FromLine];
                m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                NotifyMovementHandler(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                TurningToKing(i_ToRow, i_ToLine);
            }
            else
            {
                NotifyOnInvalidMove("Bad Move Please Try Again");
            }
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
        }

        public bool IsValidMove(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            bool isValid = false;
            if (m_Board[i_ToRow, i_ToLine] == ePlayer.Empty && m_Board[i_FromRow, i_FromLine] != ePlayer.Empty)
            {
                if ((i_Player.ENormalSign == ePlayer.O) && (m_Board[i_FromRow, i_FromLine] == i_Player.ENormalSign))
                {
                    if (i_FromRow == i_ToRow - 1 && (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                    {
                        isValid = true;
                    }
                }
                else if ((i_Player.ENormalSign == ePlayer.X) && (m_Board[i_FromRow, i_FromLine] == i_Player.ENormalSign))
                {
                    if (i_FromRow == i_ToRow + 1 && (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                    {
                        isValid = true;
                    }
                }
                else if ((i_Player.EKinglSign == ePlayer.U || i_Player.EKinglSign == ePlayer.K) &&
                         (m_Board[i_FromRow, i_FromLine] == i_Player.EKinglSign))
                {
                    if ((i_FromRow == i_ToRow + 1 || i_FromRow == i_ToRow - 1) &&
                        (i_FromLine + 1 == i_ToLine || i_FromLine - 1 == i_ToLine))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        public void Eat(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            if (IsValidEat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine))
            {
                if (i_ToLine > i_FromLine && i_ToRow > i_FromRow)
                {
                    //bottom right
                    m_Board[i_FromRow + 2, i_FromLine + 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow + 1, i_FromLine + 1] = ePlayer.Empty;
                    //Updating UI
                    NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow + 1, i_FromLine + 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
                else if (i_ToLine < i_FromLine && i_ToRow > i_FromRow)
                {
                    //bottom left
                    m_Board[i_FromRow + 2, i_FromLine - 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow + 1, i_FromLine - 1] = ePlayer.Empty;
                    NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow + 1, i_FromLine - 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }

                else if (i_ToLine < i_FromLine && i_ToRow < i_FromRow)
                {
                    //up left
                    m_Board[i_FromRow - 2, i_FromLine - 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow - 1, i_FromLine - 1] = ePlayer.Empty;
                    NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow - 1, i_FromLine - 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
                else if (i_ToLine > i_FromLine && i_ToRow < i_FromRow)
                {
                    //up right
                    m_Board[i_FromRow - 2, i_FromLine + 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow - 1, i_FromLine + 1] = ePlayer.Empty;
                    NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow - 1, i_FromLine + 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
            }
            else
            {
                NotifyInvalidMove("Invalid eating move, please enter a correct move");
            }
        }

        public bool IsValidEat(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            bool isValid = false;
            if (i_Player.ENormalSign == ePlayer.O)
            {
                if (i_FromRow == i_ToRow - 2 && (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    //if bottom right is empty and you eat your opponent
                    if (i_ToLine - 2 == i_FromLine)
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
            else if (i_Player.ENormalSign == ePlayer.X)
            {
                if (i_FromRow == i_ToRow + 2 && (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    //if up left is empty and you eat your opponent
                    if (i_ToLine + 2 == i_FromLine)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.O ||
                             m_Board[i_ToRow + 1, i_ToLine + 1] == ePlayer.U))
                        {
                            isValid = true;
                        }
                    }
                    //if up right is empty and you eat your opponent
                    else
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.O ||
                             m_Board[i_ToRow + 1, i_ToLine - 1] == ePlayer.U))
                        {
                            isValid = true;
                        }
                    }
                }
            }
            else if (i_Player.EKinglSign == ePlayer.U || i_Player.EKinglSign == ePlayer.K)
            {
                if ((i_FromRow == i_ToRow + 2 || i_FromRow == i_ToRow - 2) &&
                    (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    if (i_Player.EKinglSign == ePlayer.U)
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

        public void CheckWhichMoveIsIt(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine, PlayerInfo i_Player,
            bool i_CanEatAgainStatus)
        {
            const bool v_IsAEatOrMove = true;
            bool isAMove = !v_IsAEatOrMove;

            if (i_CanEatAgainStatus)
            {
                Eat(i_Player, i_FromLine, i_FromRow, i_ToLine, i_ToRow);
                isAMove = v_IsAEatOrMove;
            }
            else if (m_Board[i_FromRow, i_FromLine] == i_Player.ENormalSign)
            {
                switch (i_Player.ENormalSign)
                {
                    case ePlayer.X:
                    {
                        if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                isAMove = v_IsAEatOrMove;
                            }
                        }
                        break;
                    }
                    case ePlayer.O:
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                isAMove = v_IsAEatOrMove;
                            }
                        }
                        break;
                    }
                }
            }
            else if (m_Board[i_FromLine, i_FromRow] == i_Player.EKinglSign)
            {
                if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                {
                    Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                    isAMove = v_IsAEatOrMove;
                }
                else
                {
                    if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                    {
                        Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                        isAMove = v_IsAEatOrMove;
                    }
                    else
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, k_EatMoveSteps))
                            {
                                Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                isAMove = v_IsAEatOrMove;
                            }
                        }
                    }
                }
            }
            if (!isAMove)
            {
                NotifyInvalidMove("Incorrect move , please check if its your turn or if u did a correct move");
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

        public bool CheckForEatingMovesFirst(PlayerInfo i_Player, out int[] o_ArrayOfEatingPossitions)
        {
            int indexForArray = 0;
            bool isEatingMoves = false;
            o_ArrayOfEatingPossitions = new int[m_Board.BoardSize*4];
            for (int indexFromRow = 0; indexFromRow < m_Board.BoardSize; indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < m_Board.BoardSize; indexFromLine++)
                {
                    if ((m_Board[indexFromRow, indexFromLine] == i_Player.ENormalSign) ||
                        (m_Board[indexFromRow, indexFromLine] == i_Player.EKinglSign))
                    {
                        if (i_Player.ENormalSign == ePlayer.X)
                        {
                            int indexToRow = indexFromRow - 2;
                            int indexToTopLeftLine = indexFromLine - 2;
                            int indexToTopRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToRow, indexToTopLeftLine))
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
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToRow, indexToTopRightLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToRow, indexToTopRightLine))
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
                        else if (i_Player.ENormalSign == ePlayer.O)
                        {
                            int indexToRow = indexFromRow + 2;
                            int indexToBottomLeftLine = indexFromLine - 2;
                            int indexToBottomRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToRow,
                                    indexToBottomLeftLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToRow, indexToBottomLeftLine))
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
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToRow,
                                    indexToBottomRightLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToRow,
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
                        else if (i_Player.EKinglSign == ePlayer.K || i_Player.EKinglSign == ePlayer.U)
                        {
                            int indexToUpRow = indexFromRow + 2;
                            int indexToTopLeftLine = indexFromLine - 2;
                            int indexToTopRightLine = indexFromLine + 2;
                            int indexToDownRow = indexFromRow - 2;
                            int indexToBottomLeftLine = indexFromLine - 2;
                            int indexToBottomRightLine = indexFromLine + 2;
                            if (
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomLeftLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToUpRow,
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
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToUpRow,
                                    indexToBottomRightLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToUpRow,
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
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopRightLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToDownRow,
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
                                IsValidMove(i_Player, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToTopLeftLine) &&
                                IsValidEat(i_Player, indexFromRow, indexFromLine, indexToDownRow,
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

        public bool IsChoosedEatingFirst(ePlayer i_Sign, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine,
            int[] i_ArrayOfEatingPossitions)
        {
            bool isChooshed = false;
            for (int i = 0; i < i_ArrayOfEatingPossitions.Length; i += 4)
            {
                if (i_FromRow == i_ArrayOfEatingPossitions[i] && i_FromRow == i_ArrayOfEatingPossitions[i + 1] &&
                    i_FromRow == i_ArrayOfEatingPossitions[i + 2] && i_FromRow == i_ArrayOfEatingPossitions[i + 3])
                {
                    isChooshed = true;
                }
            }
            return isChooshed;
        }

        //Osher to add UI
        public void TurningToKing(int i_ToRow, int i_ToLine)
        {
            if (i_ToRow == 0)
            {
                if (m_Board[i_ToRow, i_ToLine] == ePlayer.X)
                {
                    m_Board[i_ToRow, i_ToLine] = ePlayer.K;
                    //m_NumberOfK++;
                    //m_NumberOfX--;
                }
            }
            else
            {
                if (i_ToRow == m_Board.BoardSize - 1)
                {
                    if (m_Board[i_ToRow, i_ToLine] == ePlayer.O)
                    {
                        m_Board[i_ToRow, i_ToLine] = ePlayer.U;
                        // m_NumberOfU++;
                        //m_NumberOfO--;
                    }
                }
            }
        }
    }
}


