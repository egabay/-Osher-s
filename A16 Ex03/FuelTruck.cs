using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class FuelTruck : FuelVehicle
    {
        protected const int k_NumberOfWheels = 12;
        internal static float s_MaximumAirPressure = 34; 
        internal static Enums.eFuelType s_FuelType = Enums.eFuelType.Soler;
        internal static float s_LitersFuelTank = 160;
        protected float m_MaximumCarryingWeight;
        protected bool m_IsCarryDangerousMaterials;


        public FuelTruck(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercent, 
            string i_WheelManufacturName, float i_CurrentAirPressure, float i_CurrentFuelAmountByLiters, 
            float mMaximumCarryingWeight, bool mIsCarryDangerousMaterials) :
            base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, k_NumberOfWheels, i_WheelManufacturName,
            i_CurrentAirPressure, s_MaximumAirPressure, s_FuelType, i_CurrentFuelAmountByLiters, s_LitersFuelTank)
        {
            m_MaximumCarryingWeight = mMaximumCarryingWeight;
            m_IsCarryDangerousMaterials = mIsCarryDangerousMaterials;
        }

        public float TruckMaximumCarryingWeight
        {
            get { return m_MaximumCarryingWeight; }
            set { m_MaximumCarryingWeight = value; }
        }

        public bool IsCarryDangerousMaterials
        {
            get { return m_IsCarryDangerousMaterials; }
            set { m_IsCarryDangerousMaterials = value; }
        }
    }
}
