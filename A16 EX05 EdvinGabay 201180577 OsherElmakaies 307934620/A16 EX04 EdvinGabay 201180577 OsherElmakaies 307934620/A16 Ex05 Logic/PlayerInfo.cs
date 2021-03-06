﻿﻿using System;
using System.Collections.Generic;
using System.Text;


public enum PlayerType
{
    Human,
    Computer
};

namespace Ex05
{
    public class PlayerInfo
    {
        private string m_Name;
        private int m_NumberOfWins;
        private int m_Score; 
        private ePlayer m_NormalSign;
        private ePlayer m_KinglSign;
        private PlayerType m_Type;
        
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


        public PlayerType PlayingType
        {
            get { return m_Type; }
            set { m_Type = value; }
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
    }
}