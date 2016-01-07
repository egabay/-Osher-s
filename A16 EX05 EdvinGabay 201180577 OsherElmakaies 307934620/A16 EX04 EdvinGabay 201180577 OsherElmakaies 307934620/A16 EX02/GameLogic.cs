using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{
    public class GameLogic
    {
        public void Move(Button i_From, Button i_To)
        {
            // if (IsGoodMoveData(i_MoveFromTo))//To create new method
            // {

            i_To.Text = i_From.Text;
            i_From.Text = string.Empty;
            //  }
            //  else
            //  {
            //    throw new System.ArgumentException(
            //       "Parameters Format incorrect please re-enter new parameters in the correct format");
            // }
        }

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
                                i_EatenPlayer = m_TableMatrix[moveToRowIndex - 1, moveToLineIndex - 1];
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

        }
    }
}
