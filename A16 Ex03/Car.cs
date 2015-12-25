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

        public Car(string i_VehicleModelName, string i_VehicleLicenseNumber,
            float i_VehicleEnergyPercent, eNumberOfWheels i_VehicleNumberOfWheels,
            string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure,
            eNumberOfDoors i_NumberOfDoors, eColor i_Color) :
                base(i_VehicleModelName, i_VehicleLicenseNumber, i_VehicleEnergyPercent,
                    i_VehicleNumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
            m_NumberOfWheels = eNumberOfWheels.Four;
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
    }
}
