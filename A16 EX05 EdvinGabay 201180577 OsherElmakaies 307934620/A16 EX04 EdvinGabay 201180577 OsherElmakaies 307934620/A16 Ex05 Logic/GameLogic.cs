using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ex05
{
    public delegate void MovedOccuredDelegate(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow);

    public delegate void NotifyEatingOccuredDelegate(
        int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow, int i_EatenLine, int i_EatenRow);

    public delegate void UpdateInfoFromSettingDialogDelegate(
        int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName);

    public delegate void NotifyInvalidMove(string i_InvalidMoveMsg);

    public delegate void ChangeToKing(int i_Row, int i_Line, ePlayer i_Player);

    public class GameLogic
    {
        Board m_Board;
        public const int v_RegularMoveSteps = 1;
        public const int v_EatMoveSteps = 2;
        readonly List<EatCordinates> m_ListOfPossibleEatingMoves = new List<EatCordinates>();
        readonly List<MoveCordinates> m_ListOfPossibleStepMoves = new List<MoveCordinates>();

        public GameLogic(int i_BoardSize)
        {
            InitializeBoard(i_BoardSize);
        }

        private void InitializeBoard(int i_BoardSize)
        {
            m_Board = new Board(i_BoardSize);
        }

        /// Updating the GUI With delegate that movement occured 
        public event MovedOccuredDelegate m_NotifyMovement;

        public event ChangeToKing m_NotifyToUpdateKing;
        public event NotifyEatingOccuredDelegate m_NotifyEat;
        public event NotifyInvalidMove m_NotifyInvalidMove;

        private void NotifyMovementHandler(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            m_NotifyMovement(i_FromRow, i_FromLine, i_ToRow, i_ToLine);
        }

        private void NotifyOnEatOccured(int i_FromLine, int i_FromRow, int i_ToLine, int i_ToRow, int i_EatenLine,
            int i_EatenRow)
        {
            m_NotifyEat(i_FromLine, i_FromRow, i_ToLine, i_ToRow, i_EatenLine, i_EatenRow);
        }

        private void NotifyOnInvalidMove(string i_MsgToNotify)
        {
            m_NotifyInvalidMove(i_MsgToNotify);
        }

        private void NotifyChangeToKing(int i_Row, int i_Line, ePlayer i_Player)
        {
            m_NotifyToUpdateKing(i_Row, i_Line, i_Player);
        }

        //------------------------------------------------------

        public bool IsEmptyPlace(int i_ToRow, int i_ToLine)
        {
            bool isEmpty = m_Board[i_ToRow, i_ToLine] == ePlayer.Empty;
            return isEmpty;
        }

        public void Move(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            CheckForEatingMovesFirst(i_Player);
            if (m_ListOfPossibleEatingMoves.Count == 0)
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
            }
            else
            {
                NotifyOnInvalidMove("Please perform Eating before trying to do a regular move");
            }
            //Checking if table match gui(Delete it after) 3 = X / 1 = O
            //for (int i = 0; i < m_Board.BoardSize; i++)
            //{
            //    for (int j = 0; j < m_Board.BoardSize; j++)
            //    {
            //        Console.Write(Convert.ToInt32(m_Board[i, j]) + " |");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("======================================================");
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
                    m_NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow + 1, i_FromLine + 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
                else if (i_ToLine < i_FromLine && i_ToRow > i_FromRow)
                {
                    //bottom left
                    m_Board[i_FromRow + 2, i_FromLine - 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow + 1, i_FromLine - 1] = ePlayer.Empty;
                    m_NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow + 1, i_FromLine - 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }

                else if (i_ToLine < i_FromLine && i_ToRow < i_FromRow)
                {
                    //up left
                    m_Board[i_FromRow - 2, i_FromLine - 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow - 1, i_FromLine - 1] = ePlayer.Empty;
                    m_NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow - 1, i_FromLine - 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
                else if (i_ToLine > i_FromLine && i_ToRow < i_FromRow)
                {
                    //up right
                    m_Board[i_FromRow - 2, i_FromLine + 2] = m_Board[i_FromRow, i_FromLine];
                    m_Board[i_FromRow, i_FromLine] = ePlayer.Empty;
                    m_Board[i_FromRow - 1, i_FromLine + 1] = ePlayer.Empty;
                    m_NotifyEat(i_FromRow, i_FromLine, i_ToRow, i_ToLine, i_FromRow - 1, i_FromLine + 1);
                    TurningToKing(i_ToRow, i_ToLine);
                }
                int indexToNewRow;
                int indexToNewLine;
                int indexEatenNewRow;
                int indexEatenNewLine;
                if (IsEatingMoveAroundYou(i_Player, i_ToRow, i_ToLine, out indexToNewRow, out indexToNewLine, out indexEatenNewRow, out indexEatenNewLine))
                {
                    //Osher - need to leave the turn to the current player
                }
            }
            else
            {
                m_NotifyInvalidMove("Invalid eating move, please enter a correct move");
            }
        }

        public bool IsValidEat(PlayerInfo i_Player, int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine)
        {
            bool isValid = false;
            if ((i_Player.ENormalSign == ePlayer.O) && (m_Board[i_FromRow, i_FromLine]) == i_Player.ENormalSign)
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
            else if ((i_Player.ENormalSign == ePlayer.X) && (m_Board[i_FromRow, i_FromLine]) == i_Player.ENormalSign)
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
            else if ((i_Player.EKinglSign == ePlayer.U || i_Player.EKinglSign == ePlayer.K) &&
                     (m_Board[i_FromRow, i_FromLine]) == i_Player.EKinglSign)
            {
                if ((i_FromRow == i_ToRow + 2 || i_FromRow == i_ToRow - 2) &&
                    (i_FromLine + 2 == i_ToLine || i_FromLine - 2 == i_ToLine))
                {
                    //if bottom right
                    if (i_ToLine - 2 == i_FromLine && i_FromRow + 2 == i_ToRow)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow - 1, i_ToLine - 1] != i_Player.ENormalSign && m_Board[i_ToRow - 1, i_ToLine - 1] != ePlayer.Empty && 
                             m_Board[i_ToRow - 1, i_ToLine - 1] != i_Player.EKinglSign))
                        {
                            isValid = true;
                        }
                    }
                    //if bottom left
                    if (i_ToLine + 2 == i_FromLine && i_FromRow + 2 == i_ToRow)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow - 1, i_ToLine + 1] != i_Player.ENormalSign && m_Board[i_ToRow - 1, i_ToLine + 1] != ePlayer.Empty && 
                             m_Board[i_ToRow - 1, i_ToLine + 1] != i_Player.EKinglSign))
                        {
                            isValid = true;
                        }
                    }
                    //if up right
                    if (i_ToLine - 2 == i_FromLine && i_FromRow == i_ToRow + 2)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine - 1] != i_Player.ENormalSign && m_Board[i_ToRow + 1, i_ToLine - 1] != ePlayer.Empty && 
                             m_Board[i_ToRow + 1, i_ToLine - 1] != i_Player.EKinglSign))
                        {
                            isValid = true;
                        }
                    }
                    //if up left
                    if (i_ToLine + 2 == i_FromLine && i_FromRow == i_ToRow + 2)
                    {
                        if (IsEmptyPlace(i_ToRow, i_ToLine) &&
                            (m_Board[i_ToRow + 1, i_ToLine + 1] != i_Player.ENormalSign && m_Board[i_ToRow + 1, i_ToLine + 1] != ePlayer.Empty && 
                             m_Board[i_ToRow + 1, i_ToLine + 1] != i_Player.EKinglSign))
                        {
                            isValid = true;
                        }
                    }
                }
            }
            return isValid;
        }


        public void CheckWhichMoveIsIt(int i_FromRow, int i_FromLine, int i_ToRow, int i_ToLine, PlayerInfo i_Player)
        {
            m_ListOfPossibleEatingMoves.Clear();
            const bool v_IsAEatOrMove = true;
            bool isAMove = !v_IsAEatOrMove;
            CheckForEatingMovesFirst(i_Player);
            if (!IsMoveStepAvailble(i_Player) && m_ListOfPossibleEatingMoves[0] == null)
            {
                m_NotifyInvalidMove("You don't have any moves to do!");
            }
            else if (m_Board[i_FromRow, i_FromLine] == i_Player.ENormalSign)
            {
                switch (i_Player.ENormalSign)
                {
                    case ePlayer.X:
                    {
                        if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_EatMoveSteps))
                            {
                                Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                isAMove = v_IsAEatOrMove;
                            }
                        }
                        break;
                    }
                    case ePlayer.O:
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_EatMoveSteps))
                            {
                                Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                                isAMove = v_IsAEatOrMove;
                            }
                        }
                        break;
                    }
                }
            }
            //else if (m_Board[i_FromLine, i_FromRow] == i_Player.EKinglSign)
            else
            {
                if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_RegularMoveSteps))
                {
                    Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                    isAMove = v_IsAEatOrMove;
                }
                else
                {
                    if (IsXDirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_EatMoveSteps))
                    {
                        Eat(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                        isAMove = v_IsAEatOrMove;
                    }
                    else
                    {
                        if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_RegularMoveSteps))
                        {
                            Move(i_Player, i_FromRow, i_FromLine, i_ToRow, i_ToLine);
                            isAMove = v_IsAEatOrMove;
                        }
                        else
                        {
                            if (IsODirectionMove(i_FromRow, i_ToRow, i_FromLine, i_ToLine, v_EatMoveSteps))
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
                m_NotifyInvalidMove("Incorrect move , please check if its your turn or if you did a correct move");
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

        public void CheckForEatingMovesFirst(PlayerInfo i_Player)
        {
            int indexToRow;
            int indexToLine;
            int indexEatenPlaceRow;
            int indexEatenPlaceLine;
            for (int indexFromRow = 0; indexFromRow < m_Board.BoardSize; indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < m_Board.BoardSize; indexFromLine++)
                {
                    if (IsEatingMoveAroundYou(i_Player, indexFromRow, indexFromLine, out indexToRow,
                        out indexToLine, out indexEatenPlaceRow, out indexEatenPlaceLine))
                    {
                        EatCordinates eatingPosition = new EatCordinates(indexFromRow, indexFromLine,
                            indexToRow, indexToLine, indexEatenPlaceRow, indexEatenPlaceLine);
                        m_ListOfPossibleEatingMoves.Add(eatingPosition);
                    }
                }
            }
        }

        //Osher to add UI
        public void TurningToKing(int i_ToRow, int i_ToLine)
        {
            if (i_ToRow == 0)
            {
                if (m_Board[i_ToRow, i_ToLine] == ePlayer.X)
                {
                    m_Board[i_ToRow, i_ToLine] = ePlayer.K;
                    NotifyChangeToKing(i_ToRow, i_ToLine, ePlayer.K);
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
                        NotifyChangeToKing(i_ToRow, i_ToLine, ePlayer.U);
                        // m_NumberOfU++;
                        //m_NumberOfO--;
                    }
                }
            }
        }

        public bool IsEatingMoveAroundYou(PlayerInfo i_Player, int i_FromRow, int i_FromLine, out int o_ToRow,
            out int o_ToLine, out int o_EatenPlaceRow, out int o_EatenPlaceLine)
        {
            bool k_IsEatable = true;
            bool retVal = !k_IsEatable;
            int indexToUpRow = i_FromRow - 2;
            int indexToTopLeftLine = i_FromLine - 2;
            int indexToTopRightLine = i_FromLine + 2;
            int indexToDownRow = i_FromRow + 2;
            int indexToBottomLeftLine = i_FromLine - 2;
            int indexToBottomRightLine = i_FromLine + 2;
            o_ToRow = 0;
            o_ToLine = 0;
            o_EatenPlaceRow = 0;
            o_EatenPlaceLine = 0;
            //Top left
            if (IsInRange(indexToUpRow, indexToTopLeftLine))
            {
                if (IsValidEat(i_Player, i_FromRow, i_FromLine, indexToUpRow, indexToTopLeftLine))
                {
                    o_ToRow = indexToUpRow;
                    o_ToLine = indexToTopLeftLine;
                    o_EatenPlaceRow = indexToUpRow + 1;
                    o_EatenPlaceLine = indexToTopLeftLine + 1; 
                    retVal = k_IsEatable;
                }
            }
            //Top right
            if (IsInRange(indexToUpRow, indexToTopRightLine))
            {
                if (IsValidEat(i_Player, i_FromRow, i_FromLine, indexToUpRow, indexToTopRightLine))
                {
                    o_ToRow = indexToUpRow;
                    o_ToLine = indexToTopRightLine;
                    o_EatenPlaceRow = indexToUpRow + 1;
                    o_EatenPlaceLine = indexToTopRightLine - 1; 
                    retVal = k_IsEatable;
                }
            }
            //Bottom left
            if (IsInRange(indexToDownRow, indexToBottomLeftLine))
            {
                if (IsValidEat(i_Player, i_FromRow, i_FromLine, indexToDownRow, indexToBottomLeftLine))
                {
                    o_ToRow = indexToDownRow;
                    o_ToLine = indexToBottomLeftLine;
                    o_EatenPlaceRow = indexToDownRow - 1;
                    o_EatenPlaceLine = indexToBottomLeftLine + 1; 
                    retVal = k_IsEatable;
                }
            }
            //Bottom right
            if (IsInRange(indexToDownRow, indexToBottomRightLine))
            {
                if (IsValidEat(i_Player, i_FromRow, i_FromLine, indexToDownRow, indexToBottomRightLine))
                {
                    o_ToRow = indexToDownRow;
                    o_ToLine = indexToBottomRightLine;
                    o_EatenPlaceRow = indexToDownRow - 1;
                    o_EatenPlaceLine = indexToBottomLeftLine - 1; 
                    retVal = k_IsEatable;
                }
            }
            return retVal;
        }

        public bool IsInRange(int i_ToRow, int i_ToLine)
        {
            bool isInRange =
                !(i_ToRow > m_Board.BoardSize - 1 || i_ToRow < 0 || i_ToLine > m_Board.BoardSize - 1 || i_ToLine < 0);
            return isInRange;
        }

        public bool IsMoveStepAvailble(PlayerInfo i_Player)
        {
            bool isMoveStepsAvailble = false;
            int indexFromRow;
            for (indexFromRow = 0; indexFromRow < m_Board.BoardSize; indexFromRow++)
            {
                int indexFromLine;
                for (indexFromLine = 0; indexFromLine < m_Board.BoardSize; indexFromLine++)
                {
                    int indexToUpRow = indexFromRow - 1;
                    int indexToTopLeftLine = indexFromLine - 1;
                    int indexToTopRightLine = indexFromLine + 1;
                    int indexToDownRow = indexFromRow + 1;
                    int indexToBottomLeftLine = indexFromLine - 1;
                    int indexToBottomRightLine = indexFromLine + 1;
                    if (IsInRange(indexToDownRow, indexToBottomRightLine))
                    {
                        if (i_Player.ENormalSign == ePlayer.O || i_Player.ENormalSign == ePlayer.U ||
                            i_Player.ENormalSign == ePlayer.K)
                        {
                            //bottom right
                            if (IsValidMove(i_Player, indexFromRow, indexFromLine, indexToDownRow,
                                indexToBottomRightLine))
                            {
                                MoveCordinates movePosition = new MoveCordinates(indexFromRow, indexFromLine,
                            indexToDownRow, indexToBottomRightLine);
                                m_ListOfPossibleStepMoves.Add(movePosition);
                                isMoveStepsAvailble = true;
                            }
                            //bottom left
                            else if (IsInRange(indexToDownRow, indexToBottomLeftLine))
                            {
                                if (IsValidMove(i_Player, indexFromRow, indexFromLine, indexToDownRow,
                                    indexToBottomLeftLine))
                                {
                                    MoveCordinates movePosition = new MoveCordinates(indexFromRow, indexFromLine,
                            indexToDownRow, indexToBottomLeftLine);
                                    m_ListOfPossibleStepMoves.Add(movePosition);
                                    isMoveStepsAvailble = true;
                                }
                            }
                        }
                    }
                    if (!IsInRange(indexToUpRow, indexToTopRightLine)) continue;
                    if (i_Player.ENormalSign != ePlayer.X && i_Player.ENormalSign != ePlayer.U &&
                        i_Player.ENormalSign != ePlayer.K) continue;
                    //top right
                    if (IsValidMove(i_Player, indexFromRow, indexFromLine, indexToUpRow, indexToTopRightLine))
                    {
                        MoveCordinates movePosition = new MoveCordinates(indexFromRow, indexFromLine,
                            indexToUpRow, indexToTopRightLine);
                        m_ListOfPossibleStepMoves.Add(movePosition);
                        isMoveStepsAvailble = true;
                    }
                    //top left
                    else if (IsInRange(indexToUpRow, indexToTopLeftLine))
                    {
                        if (IsValidMove(i_Player, indexFromRow, indexFromLine, indexToUpRow, indexToTopLeftLine))
                        {
                            MoveCordinates movePosition = new MoveCordinates(indexFromRow, indexFromLine,
                            indexToUpRow, indexToTopLeftLine);
                            m_ListOfPossibleStepMoves.Add(movePosition);
                            isMoveStepsAvailble = true;
                        }
                    }
                }
            }
            return isMoveStepsAvailble;
        }
    }
}


