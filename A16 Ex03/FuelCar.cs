using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    internal class FuelCar : FuelVehicle
    {
        protected const int k_NumberOfWheels = 4;
        internal static float s_MaxWheelsAirPressure = 29;
        internal static float s_LitersFuelTank = 42;
        internal static Enums.eFuelType s_CarFuleType = Enums.eFuelType.Octan98;

        protected Enums.eCarColor m_Color; 
        protected Enums.eCarNumberOfDoors m_NumberOfDoors;


        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercent, 
            string i_WheelManufacturName, float i_CurrentAirPressure, 
            float i_CurrentFuelAmountByLiters, 
            Enums.eCarColor i_CarColor, 
            Enums.eCarNumberOfDoors i_CarNumberOfDoors) :
            base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, k_NumberOfWheels,
            i_WheelManufacturName, i_CurrentAirPressure, s_MaxWheelsAirPressure, s_CarFuleType,
            i_CurrentFuelAmountByLiters, s_LitersFuelTank)
        {
            m_Color = i_CarColor;
            m_NumberOfDoors = i_CarNumberOfDoors;
        }

        public Enums.eCarColor eCarColor
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public Enums.eCarNumberOfDoors eCarNumbersOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }


    }
}
