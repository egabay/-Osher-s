﻿using System;
using System.Collections.Generic;
using System.Text;
﻿using Ex02_Baord;


namespace Ex02_New
{
    class PlayerInfo
    {
        private string m_Name;
        private int m_NumberOfWins;
        private int m_Score; 
        private ePlayer m_NormalSign;
        private ePlayer m_KinglSign;
        public int PawnsNumber { get; private set; }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public PlayerInfo(string i_Name, ePlayer i_ENormalPlayerSign, ePlayer i_EKingPlayerSign)
        {
            Name = i_Name;
            ENormalSign = i_ENormalPlayerSign;
            EKinglSign = i_EKingPlayerSign;
            PlayerAmountOfWins = 0;
        }

        public ePlayer ENormalSign
        {
            get { return m_NormalSign; }
            set { m_NormalSign = value; }
        }

        public ePlayer EKinglSign
        {
            get { return m_KinglSign; }
            set { m_KinglSign = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int PlayerAmountOfWins
        {
            get
            {
                return m_NumberOfWins;
            }
            set { m_NumberOfWins = value; }
        }

        public void UpdatePawnsNumber(int i_Number)
        {
            PawnsNumber = i_Number;
        }

        public bool CanEatAgain(int i_MoveFromLineIndex, int i_MoveFromRowIndex, Board m_Table, ePlayer i_ESign)
        {
            bool answerForEatingAgain = false;
            string currentLocation = m_Table[i_MoveFromRowIndex, i_MoveFromLineIndex].ToString();
            string bottomRight = m_Table[i_MoveFromRowIndex + 1, i_MoveFromLineIndex + 1].ToString();
            string bottomLeft = m_Table[i_MoveFromRowIndex + 1, i_MoveFromLineIndex - 1].ToString();
            string topLeft = m_Table[i_MoveFromRowIndex - 1, i_MoveFromLineIndex + 1].ToString();
            string topRight = m_Table[i_MoveFromRowIndex - 1, i_MoveFromLineIndex - 1].ToString();
            if (CheckForOpponentAroundYou(currentLocation, bottomRight))
            {
                if (CheckEmptyAroundYou(bottomRight))
                {
                    answerForEatingAgain = true;
                }
            }
            if (CheckForOpponentAroundYou(currentLocation, bottomLeft))
            {
                if (CheckEmptyAroundYou(bottomLeft))
                {
                    answerForEatingAgain = true;
                }
            }
            if (CheckForOpponentAroundYou(currentLocation, topLeft))
            {
                if (CheckEmptyAroundYou(topLeft))
                {
                    answerForEatingAgain = true;
                }
            }
            if (CheckForOpponentAroundYou(currentLocation, topRight))
            {
                if (CheckEmptyAroundYou(topRight))
                {
                    answerForEatingAgain = true;
                }
            }
            // $G$ CSS-006 (-3) missing blank line.
            return answerForEatingAgain;

        }

        public bool CheckForOpponentAroundYou(string i_CurrentLocation, string i_OpponentLocation)
        {
            bool answerForOpponent = false;
            ePlayer opponentSign;
            opponentSign = (ENormalSign == ePlayer.X) ? ePlayer.O : ePlayer.X;
            if (i_CurrentLocation != opponentSign.ToString())
            {
                answerForOpponent = true;
            }
            return answerForOpponent;
        }

        public bool CheckEmptyAroundYou(string i_CurrentLocation)
        {

            bool answerForEmptyPlace = i_CurrentLocation.Equals(ePlayer.Empty.ToString());
            return answerForEmptyPlace;
        }
    }
}