using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Red,
        Blue,
        Black,
        White
    }

    public enum eNumberOfDoors
    {
        Two,
        Three,
        Four,
        Five
    }


    public class Car : Vehicle
    {
        protected const int k_NumberOfWheels = 4;
        internal static float s_MaxWheelsAirPressure = 29;
        private Engine m_Engine;
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;



        public Car()
        {

        }

        protected override string GetAttributes()
        {
            string retVal;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Number Of Doors : {0}, Car Color : {1}", m_NumberOfDoors.ToString(), m_Color.ToString());
            retVal = builder.ToString();
            return retVal;
        }

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
        public sealed override object FirstDifferentProperty
        {
            get { return m_Color; }
            set { m_Color = (eColor)value; }
        }
        public sealed override object SecondDifferentProperty
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = (eNumberOfDoors)value; }
        }
    }
}
