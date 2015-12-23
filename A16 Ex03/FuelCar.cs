using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    internal class FuelCar : FuelVehicle
    {
        protected const int k_CarNumberOfWheels = 4;
        internal static float s_MaxWheelsAirPressure = 29;
        internal static float s_LitersFuelTank = 42;
        
        protected Enums.eCarColor m_CarColor;
        protected Enums.eCarNumberOfDoors m_CarNumberOfDoors;


        public FuelCar(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercent, 
            int i_NumberOfWheel, string i_WheelManufacturName, float i_CurrentAirPressure, 
            float i_MaximumAirPressure, Enums.eFuelType i_FuleType, float i_CurrentFuelAmountByLiters, 
            float i_MaximunFuelAmountByLiters, Enums.eCarColor i_CarColor, 
            Enums.eCarNumberOfDoors i_CarNumberOfDoors) : 
            base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, i_NumberOfWheel, 
            i_WheelManufacturName, i_CurrentAirPressure, i_MaximumAirPressure, i_FuleType, 
            i_CurrentFuelAmountByLiters, i_MaximunFuelAmountByLiters)
        {
            m_CarColor = i_CarColor;
            m_CarNumberOfDoors = i_CarNumberOfDoors;
        }
    }
}
