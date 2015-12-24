using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    enum eColor
    {
        Red,
        Blue,
        Black,
        White
    }

    enum eNumberOfDoors
    {
        Two,
        Three,
        Four,
        Five
    }
    
    
    internal class Car : Vehicle
    {
        protected const int k_NumberOfWheels = 4;
        internal static float s_MaxWheelsAirPressure = 29;
        private Engine m_Engine;
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        
        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }


    }
}
