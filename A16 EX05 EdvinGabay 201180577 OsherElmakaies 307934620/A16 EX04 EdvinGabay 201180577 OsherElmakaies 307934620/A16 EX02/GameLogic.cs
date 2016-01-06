using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;
using Ex02_Baord;
namespace Ex02_New
{
    public class GameLogic
    {
        // $G$ DSN-004 (-5) Code Duplication! you can calculate indexes in a separate method then send it to a more generic method.
        private Board m_Game;

        public void Eat(string i_MoveFromTo, ePlayer i_EPlayerSign, bool i_IsEatableStatus)
        {
            ePlayer i_EatenPlayer = ePlayer.Empty;
            int moveFromLineIndex, moveFromRowIndex, moveToLineIndex, moveToRowIndex;
            const bool k_IsValid = true;
            bool isValid = !k_IsValid;

            if (IsGoodMoveData(i_MoveFromTo))
            {
                ConvertToIndexNumbers(i_MoveFromTo, out moveFromLineIndex, out moveFromRowIndex, out moveToLineIndex,
                    out moveToRowIndex);

                if (IsValidMove(moveFromLineIndex, moveFromRowIndex, moveToLineIndex, moveToRowIndex))
                {
                    if (moveToRowIndex > moveFromRowIndex)
                    {
                        if (moveToLineIndex > moveFromLineIndex)
                        {
                            if (IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, moveToRowIndex, moveToLineIndex))
                            {
                                i_EatenPlayer = m_Game.m_TableMatrix[moveToRowIndex - 1, moveToLineIndex - 1];
                                m_TableMatrix[moveToRowIndex - 1, moveToLineIndex - 1] = ePlayer.Empty;
                                Move(i_MoveFromTo, i_EPlayerSign);
                                isValid = k_IsValid;
                            }
                        }
                        else
                        {
                            if (IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, moveToRowIndex, moveToLineIndex))
                            {
                                i_EatenPlayer = m_TableMatrix[moveToRowIndex - 1, moveToLineIndex + 1];
                                m_TableMatrix[moveToRowIndex - 1, moveToLineIndex + 1] = ePlayer.Empty;
                                Move(i_MoveFromTo, i_EPlayerSign);
                                isValid = k_IsValid;
                            }
                        }
                    }
                    else
                    {
                        if (moveToLineIndex > moveFromLineIndex)
                        {
                            if (IsEatable(eMoveDirection.TopRight, i_EPlayerSign, moveToRowIndex, moveToLineIndex))
                            {
                                i_EatenPlayer = m_TableMatrix[moveToRowIndex + 1, moveToLineIndex - 1];
                                m_TableMatrix[moveToRowIndex + 1, moveToLineIndex - 1] = ePlayer.Empty;
                                Move(i_MoveFromTo, i_EPlayerSign);
                                isValid = k_IsValid;
                            }
                        }
                        else
                        {
                            if (IsEatable(eMoveDirection.TopLeft, i_EPlayerSign, moveToRowIndex, moveToLineIndex))
                            {
                                i_EatenPlayer = m_TableMatrix[moveToRowIndex + 1, moveToLineIndex + 1];
                                m_TableMatrix[moveToRowIndex + 1, moveToLineIndex + 1] = ePlayer.Empty;
                                Move(i_MoveFromTo, i_EPlayerSign);
                                isValid = k_IsValid;
                            }
                        }
                    }
                    TurningToKing(moveToRowIndex, moveToLineIndex);
                }
                if (!isValid)
                {
                    Screen.Clear();
                    throw new System.ArgumentException("Bad move , Check the move again please");
                }
                else
                {
                    TurningToKing(moveToRowIndex, moveToLineIndex);
                    if (i_EatenPlayer == ePlayer.O)
                    {
                        m_NumberOfO--;
                    }
                    else if (i_EatenPlayer == ePlayer.U)
                    {
                        m_NumberOfU--;
                    }
                    else if (i_EatenPlayer == ePlayer.K)
                    {
                        m_NumberOfK--;
                    }
                    else
                    {
                        m_NumberOfX--;
                    }
                }
            }
        }

        // $G$ DSN-003 (-5) This method is too long. 
        public bool IsEatable(eMoveDirection i_EMoveDirection, ePlayer i_EPlayerSign, int i_MoveToRowIndex,
            int i_MoveToLineIndex)
        {
            const bool v_IsEatable = true;
            bool retVal = !v_IsEatable;
            ePlayer currentPlayerOtherSign = ePlayer.Empty;
            if (i_EPlayerSign == ePlayer.X)
            {
                currentPlayerOtherSign = ePlayer.K;
            }
            else if (i_EPlayerSign == ePlayer.O)
            {
                currentPlayerOtherSign = ePlayer.U;
            }
            else if (i_EPlayerSign == ePlayer.K)
            {
                currentPlayerOtherSign = ePlayer.X;
            }
            else
            {
                currentPlayerOtherSign = ePlayer.O;
            }
            switch (i_EMoveDirection)
            {
                case eMoveDirection.TopLeft:
                {
                    if ((m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex + 1] != ePlayer.Empty) &&
                        m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex + 1] != currentPlayerOtherSign &&
                        (i_EPlayerSign.ToString() !=
                         m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex + 1].ToString()))
                    {
                        retVal = v_IsEatable;
                    }
                    break;
                }
                case eMoveDirection.TopRight:
                {
                    if ((m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex - 1] != ePlayer.Empty) &&
                        m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex - 1] != currentPlayerOtherSign &&
                        (i_EPlayerSign.ToString() !=
                         m_TableMatrix[i_MoveToRowIndex + 1, i_MoveToLineIndex - 1].ToString()))
                    {
                        retVal = v_IsEatable;
                    }
                    break;
                }
                case eMoveDirection.BottomLeft:
                {
                    if ((m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex + 1] != ePlayer.Empty) &&
                        m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex + 1] != currentPlayerOtherSign &&
                        (i_EPlayerSign.ToString() !=
                         m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex + 1].ToString()))
                    {
                        retVal = v_IsEatable;
                    }
                    break;
                }
                case eMoveDirection.BottomRight:
                {
                    if ((m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex - 1] != ePlayer.Empty) &&
                        m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex - 1] != currentPlayerOtherSign &&
                        (i_EPlayerSign.ToString() !=
                         m_TableMatrix[i_MoveToRowIndex - 1, i_MoveToLineIndex - 1].ToString()))
                    {
                        retVal = v_IsEatable;
                    }
                    break;
                }
            }
            return retVal;
        }

        
        // $G$ NTT-999 (-5) This method should be private (None of the other classes used this method...)
        public void TurningToKing(int i_MoveToRowIndex, int i_MoveToLineIndex)
        {
            if (i_MoveToRowIndex == 0)
            {
                if (m_TableMatrix[i_MoveToRowIndex, i_MoveToLineIndex] == ePlayer.X)
                {
                    m_TableMatrix[i_MoveToRowIndex, i_MoveToLineIndex] = ePlayer.K;
                    m_NumberOfK++;
                    m_NumberOfX--;
                }
            }
            else
            {
                if (i_MoveToRowIndex == m_TableMatrix.GetLength(0) - 1)
                {
                    if (m_TableMatrix[i_MoveToRowIndex, i_MoveToLineIndex] == ePlayer.O)
                    {
                        m_TableMatrix[i_MoveToRowIndex, i_MoveToLineIndex] = ePlayer.U;
                        m_NumberOfU++;
                        m_NumberOfO--;
                    }
                }
            }
        }

        // $G$ DSN-001 (-5) This method does not belong in this class.
        public void Move(string i_MoveFromTo, ePlayer i_EPlayerSign)
        {
            int moveFromLineIndex, moveFromRowIndex, moveToLineIndex, moveToRowIndex;
            if (IsGoodMoveData(i_MoveFromTo))
            {
                ConvertToIndexNumbers(i_MoveFromTo, out moveFromLineIndex, out moveFromRowIndex, out moveToLineIndex,
                    out moveToRowIndex);
                if (IsValidMove(moveFromLineIndex, moveFromRowIndex, moveToLineIndex, moveToRowIndex) &&
                    (i_EPlayerSign == m_TableMatrix[moveFromRowIndex, moveFromLineIndex]))
                {
                    m_TableMatrix[moveToRowIndex, moveToLineIndex] = m_TableMatrix[moveFromRowIndex, moveFromLineIndex];
                    m_TableMatrix[moveFromRowIndex, moveFromLineIndex] = ePlayer.Empty;
                }
                else
                {
                    throw new System.ArgumentException("Bad move , Check the move again please");
                }
            }
            else
            {
                throw new System.ArgumentException(
                    "Parameters Format incorrect please re-enter new parameters in the correct format");
            }
            TurningToKing(moveToRowIndex, moveToLineIndex);
        }

        public bool IsGoodMoveData(string i_MoveFromTo)
        {
            const bool k_IsGoodMoveData = true;
            bool retVal = k_IsGoodMoveData;
            string[] splittedMovementData = i_MoveFromTo.Split('>');

            if (splittedMovementData.Length != 2)
            {
                retVal = !k_IsGoodMoveData;
            }
            else
            {
                if ((splittedMovementData[0].Length != 2) || (splittedMovementData[1].Length != 2))
                {
                    retVal = !k_IsGoodMoveData;
                }
            }

            return retVal;
        }

        // $G$ DSN-001 (0) This method does not belong in this class.
        public bool IsValidMove(int i_MoveFromLineIndex, int i_MoveFromRowIndex, int i_MoveToLineIndex,
            int i_MoveToRowIndex)
        {
            const bool k_IsValid = true;
            bool retVal = k_IsValid;

            if ((IsInRange(i_MoveToRowIndex) && IsInRange(i_MoveToLineIndex)) &&
                (IsInRange(i_MoveFromRowIndex) && IsInRange(i_MoveFromLineIndex)))
            {
                if (m_TableMatrix[i_MoveToRowIndex, i_MoveToLineIndex] != ePlayer.Empty)
                {
                    retVal = !k_IsValid;
                }
            }
            else
            {
                retVal = !k_IsValid;
            }
            if (retVal)
            {
                if (!(isEmpty(i_MoveToRowIndex, i_MoveToLineIndex)))
                {
                    retVal = !k_IsValid;
                }
                if (isEmpty(i_MoveFromRowIndex, i_MoveFromLineIndex))
                {
                    retVal = !k_IsValid;
                }
            }
            return retVal;
        }

        private bool isEmpty(int i_RowIndex, int i_LineIndex)
        {
            const bool k_isEmpty = true;
            bool retVal = k_isEmpty;
            if ((m_TableMatrix[i_RowIndex, i_LineIndex] != ePlayer.Empty))
            {
                retVal = !k_isEmpty;
            }
            return retVal;
        }

        public bool IsInRange(int i_IndexToCheck)
        {
            const bool k_IsInRange = true;
            bool retVal = k_IsInRange;
            if (!((i_IndexToCheck >= 0) && (i_IndexToCheck < m_TableMatrix.GetLength(0))))
            {
                retVal = !k_IsInRange;
            }
            return retVal;
        }

        public eMoveType CheckWhichMoveIsIt(int i_MoveFromRowIndex, int i_MoveToRowIndex, int i_MoveFromLineIndex,
            int i_MoveToLineIndex, ePlayer i_EPlayerSign, bool i_CanEatAgainStatus)
        {
            eMoveType retVal = eMoveType.None;
            if (i_CanEatAgainStatus)
            {
                retVal = eMoveType.Eat;
            }
            else
            {
                switch (i_EPlayerSign)
                {
                    case ePlayer.X:
                    {
                        if (IsXDirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                            i_MoveToLineIndex,
                            k_RegularMoveSteps))
                        {
                            retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                                i_MoveToLineIndex, k_EatMoveSteps))
                            {
                                retVal = eMoveType.Eat;
                            }
                        }
                        break;
                    }
                    case ePlayer.O:
                    {
                        if (IsODirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                            i_MoveToLineIndex,
                            k_RegularMoveSteps))
                        {
                            retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsODirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                                i_MoveToLineIndex, k_EatMoveSteps))
                            {
                                retVal = eMoveType.Eat;
                            }
                        }
                        break;
                    }
                    case ePlayer.K:
                    case ePlayer.U:
                    {
                        if (IsXDirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                            i_MoveToLineIndex,
                            k_RegularMoveSteps))
                        {
                            retVal = eMoveType.Move;
                        }
                        else
                        {
                            if (IsXDirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                                i_MoveToLineIndex, k_EatMoveSteps))
                            {
                                retVal = eMoveType.Eat;
                            }
                            else
                            {
                                if (IsODirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                                    i_MoveToLineIndex, k_RegularMoveSteps))
                                {
                                    retVal = eMoveType.Move;
                                }
                                else
                                {
                                    if (IsODirectionMove(i_MoveFromRowIndex, i_MoveToRowIndex, i_MoveFromLineIndex,
                                        i_MoveToLineIndex, k_EatMoveSteps))
                                    {
                                        retVal = eMoveType.Eat;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            return retVal;
        }

        public bool IsODirectionMove(int i_MoveFromRowIndex, int i_MoveToRowIndex, int i_MoveFromLineIndex,
            int i_MoveToLineIndex, int i_StepsToMove)
        {
            const bool v_isODirectionRegularMove = true;
            bool retVal = !v_isODirectionRegularMove;

            if ((i_MoveFromRowIndex + i_StepsToMove == i_MoveToRowIndex &&
                 (i_MoveFromLineIndex == i_MoveToLineIndex - i_StepsToMove ||
                  i_MoveFromLineIndex == i_MoveToLineIndex + i_StepsToMove)))
            {
                retVal = v_isODirectionRegularMove;
            }
            return retVal;
        }

        public bool IsXDirectionMove(int i_MoveFromRowIndex, int i_MoveToRowIndex, int i_MoveFromLineIndex,
            int i_MoveToLineIndex, int i_StepsToMove)
        {
            const bool v_isXDirectionRegularMove = true;
            bool retVal = !v_isXDirectionRegularMove;

            if ((i_MoveFromRowIndex == i_MoveToRowIndex + i_StepsToMove &&
                 (i_MoveFromLineIndex == i_MoveToLineIndex - i_StepsToMove ||
                  i_MoveFromLineIndex == i_MoveToLineIndex + i_StepsToMove)))
            {
                retVal = v_isXDirectionRegularMove;
            }
            return retVal;
        }

        // $G$ DSN-001 (0) This method does not belong in this class.
        public bool CheckForEatingMovesFirst(ePlayer i_EPlayerSign, out string[] o_ArrayOfEatingPossitions)
        {
            int indexForArray = 0;
            bool isEatingMoves = false;
            o_ArrayOfEatingPossitions = new string[16];
            for (int indexFromRow = 0; indexFromRow < m_TableMatrix.GetLength(0); indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < m_TableMatrix.GetLength(0); indexFromLine++)
                {
                    if (m_TableMatrix[indexFromRow, indexFromLine] == i_EPlayerSign)
                    {
                        if (i_EPlayerSign == ePlayer.X)
                        {
                            int indexToRow = indexFromRow - 2;
                            int indexToTopLeftLine = indexFromLine - 2;
                            int indexToTopRightLine = indexFromLine + 2;
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopLeftLine, indexToRow) &&
                                IsEatable(eMoveDirection.TopLeft, i_EPlayerSign, indexToRow, indexToTopLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToTopLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToRow) &&
                                IsEatable(eMoveDirection.TopRight, i_EPlayerSign, indexToRow, indexToTopRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToTopRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                        }
                        else if (i_EPlayerSign == ePlayer.O)
                        {
                            int indexToRow = indexFromRow + 2;
                            int indexToBottomLeftLine = indexFromLine - 2;
                            int indexToBottomRightLine = indexFromLine + 2;
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToRow) &&
                                IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, indexToRow, indexToBottomLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToBottomLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToRow) &&
                                IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, indexToRow, indexToBottomRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToBottomRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
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
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToUpRow) &&
                                IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, indexToUpRow,
                                    indexToBottomLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToBottomLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToUpRow) &&
                                IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, indexToUpRow,
                                    indexToBottomRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToBottomRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopLeftLine, indexToDownRow) &&
                                IsEatable(eMoveDirection.TopLeft, i_EPlayerSign, indexToDownRow, indexToTopLeftLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToTopLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToDownRow) &&
                                IsEatable(eMoveDirection.TopRight, i_EPlayerSign, indexToDownRow, indexToTopRightLine))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToTopRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isEatingMoves = true;
                                indexForArray++;
                            }
                        }
                    }
                }
            }
            return isEatingMoves;
        }

        public bool IsAnotherEatingMoveAvailable(ePlayer i_EPlayerSign, int i_MoveFromRowIndex, int i_MoveFromLineIndex)
        {
            bool k_IsEatable = true;
            bool retVal = !k_IsEatable;
            int indexToUpRow = i_MoveFromRowIndex - 2;
            int indexToTopLeftLine = i_MoveFromLineIndex - 2;
            int indexToTopRightLine = i_MoveFromLineIndex + 2;
            int indexToDownRow = i_MoveFromRowIndex + 2;
            int indexToBottomLeftLine = i_MoveFromLineIndex - 2;
            int indexToBottomRightLine = i_MoveFromLineIndex + 2;
            if (IsValidMove(i_MoveFromLineIndex, i_MoveFromRowIndex, indexToTopLeftLine, indexToUpRow) &&
                IsEatable(eMoveDirection.TopLeft, i_EPlayerSign, indexToUpRow, indexToTopLeftLine))
            {
                retVal = k_IsEatable;
            }
            if (IsValidMove(i_MoveFromLineIndex, i_MoveFromRowIndex, indexToTopRightLine, indexToUpRow) &&
                IsEatable(eMoveDirection.TopRight, i_EPlayerSign, indexToUpRow, indexToTopRightLine))
            {
                retVal = k_IsEatable;
            }

            if (IsValidMove(i_MoveFromLineIndex, i_MoveFromRowIndex, indexToBottomLeftLine, indexToDownRow) &&
                IsEatable(eMoveDirection.BottomLeft, i_EPlayerSign, indexToDownRow, indexToBottomLeftLine))
            {
                retVal = k_IsEatable;
            }
            if (IsValidMove(i_MoveFromLineIndex, i_MoveFromRowIndex, indexToBottomRightLine, indexToDownRow) &&
                IsEatable(eMoveDirection.BottomRight, i_EPlayerSign, indexToDownRow, indexToBottomRightLine))
            {
                retVal = k_IsEatable;
            }

            return retVal;
        }

        // $G$ DSN-001 (0) This method does not belong in this class.
        public bool IsThereAWinner()
        {
            const bool v_IsAWinner = true;
            bool retVal = !v_IsAWinner;
            if (m_NumberOfO == 0 && m_NumberOfU == 0)
            {
                retVal = v_IsAWinner;
            }
            else if (m_NumberOfX == 0 && m_NumberOfK == 0)
            {
                retVal = v_IsAWinner;
            }
            return retVal;
        }

        public bool IsGotMoreMovesToDo(ePlayer i_EPlayerSign, out string[] o_ArrayOfMovingPositions, int i_TableSize)
        {
            int indexForArray = 0;
            const bool v_IsGotMoreMovesToDo = true;
            bool retVal = !v_IsGotMoreMovesToDo;
            o_ArrayOfMovingPositions = new string[16];
            for (int indexFromRow = 0; indexFromRow < i_TableSize; indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < i_TableSize; indexFromLine++)
                {
                    if (m_TableMatrix[indexFromRow, indexFromLine] == i_EPlayerSign)
                    {
                        if (i_EPlayerSign == ePlayer.X)
                        {
                            int indexToRow = indexFromRow - 1;
                            int indexToTopLeftLine = indexFromLine - 1;
                            int indexToTopRightLine = indexFromLine + 1;
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopLeftLine, indexToRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToTopLeftLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToTopRightLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                        }
                        else if (i_EPlayerSign == ePlayer.O)
                        {
                            int indexToRow = indexFromRow + 1;
                            int indexToBottomLeftLine = indexFromLine - 1;
                            int indexToBottomRightLine = indexFromLine + 1;
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToBottomLeftLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                    indexFromLine, indexToBottomRightLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                        }
                        else if (i_EPlayerSign == ePlayer.K || i_EPlayerSign == ePlayer.U)
                        {
                            int indexToUpRow = indexFromRow - 1;
                            int indexToTopLeftLine = indexFromLine - 1;
                            int indexToTopRightLine = indexFromLine + 1;
                            int indexToDownRow = indexFromRow + 1;
                            int indexToBottomLeftLine = indexFromLine - 1;
                            int indexToBottomRightLine = indexFromLine + 1;
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomLeftLine, indexToDownRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToBottomLeftLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToBottomRightLine, indexToDownRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToBottomRightLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopLeftLine, indexToUpRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToTopLeftLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                            if (IsValidMove(indexFromLine, indexFromRow, indexToTopRightLine, indexToUpRow))
                            {
                                o_ArrayOfMovingPositions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToTopRightLine,
                                    o_ArrayOfMovingPositions, indexForArray);
                                indexForArray++;
                                retVal = v_IsGotMoreMovesToDo;
                            }
                        }
                    }
                }
            }
            return retVal;
        }

        public bool AvailableMoves(ePlayer i_EPlayerSign, out string[] o_ArrayOfEatingPossitions)
        {
            int indexForArray = 0;
            bool isAvailableMoves = false;
            o_ArrayOfEatingPossitions = new string[16];
            for (int indexFromRow = 0; indexFromRow < m_TableMatrix.GetLength(0); indexFromRow++)
            {
                for (int indexFromLine = 0; indexFromLine < m_TableMatrix.GetLength(0); indexFromLine++)
                {
                    if (m_TableMatrix[indexFromRow, indexFromLine] == i_EPlayerSign)
                    {
                        if (i_EPlayerSign == ePlayer.X)
                        {
                            int indexToRow = indexFromRow - 1;
                            int indexToTopLeftLine = indexFromLine - 1;
                            int indexToTopRightLine = indexFromLine + 1;
                            if (indexToTopLeftLine >= 0)
                            {
                                if (isEmpty(indexToRow, indexToTopLeftLine))
                                {
                                    o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                        indexFromLine, indexToTopLeftLine,
                                        o_ArrayOfEatingPossitions, indexForArray);
                                    isAvailableMoves = true;
                                }
                            }
                            if (indexToTopRightLine < m_TableMatrix.GetLength(0))
                            {
                                if (isEmpty(indexToRow, indexToTopRightLine))
                                {
                                    o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow,
                                        indexToRow,
                                        indexFromLine, indexToTopRightLine,
                                        o_ArrayOfEatingPossitions, indexForArray);
                                    isAvailableMoves = true;
                                }
                            }
                        }

                        else if (i_EPlayerSign == ePlayer.O)
                        {
                            int indexToRow = indexFromRow + 1;
                            int indexToBottomLeftLine = indexFromLine - 1;
                            int indexToBottomRightLine = indexFromLine + 1;
                            if (indexToBottomLeftLine >= 0)
                            {
                                if (isEmpty(indexToRow, indexToBottomLeftLine))
                                {
                                    o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToRow,
                                        indexFromLine, indexToBottomLeftLine,
                                        o_ArrayOfEatingPossitions, indexForArray);
                                    isAvailableMoves = true;
                                }
                            }
                            if (indexToBottomRightLine < m_TableMatrix.GetLength(0))
                            {
                                if (isEmpty(indexToRow, indexToBottomRightLine))
                                {
                                    o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow,
                                        indexToRow,
                                        indexFromLine, indexToBottomRightLine,
                                        o_ArrayOfEatingPossitions, indexForArray);
                                    isAvailableMoves = true;
                                }
                            }
                        }

                        else if (i_EPlayerSign == ePlayer.K || i_EPlayerSign == ePlayer.U)
                        {
                            int indexToUpRow = indexFromRow - 1;
                            int indexToTopLeftLine = indexFromLine - 1;
                            int indexToTopRightLine = indexFromLine + 1;
                            int indexToDownRow = indexFromRow + 1;
                            int indexToBottomLeftLine = indexFromLine - 1;
                            int indexToBottomRightLine = indexFromLine + 1;
                            if (isEmpty(indexToUpRow, indexToTopLeftLine) && indexToTopLeftLine > 0)
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToTopLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isAvailableMoves = true;
                            }
                            if (isEmpty(indexToUpRow, indexToTopRightLine) &&
                                indexToTopRightLine < m_TableMatrix.GetLength(0))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToUpRow,
                                    indexFromLine, indexToTopRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isAvailableMoves = true;
                            }
                            if (isEmpty(indexToDownRow, indexToBottomLeftLine) && indexToBottomLeftLine > 0)
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToBottomLeftLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isAvailableMoves = true;
                            }
                            if (isEmpty(indexToDownRow, indexToBottomRightLine) &&
                                indexToBottomRightLine < m_TableMatrix.GetLength(0))
                            {
                                o_ArrayOfEatingPossitions[indexForArray] = ConvertToString(indexFromRow, indexToDownRow,
                                    indexFromLine, indexToBottomRightLine,
                                    o_ArrayOfEatingPossitions, indexForArray);
                                isAvailableMoves = true;
                            }
                        }
                    }
                }
            }
            return isAvailableMoves;
        }
    }
}
