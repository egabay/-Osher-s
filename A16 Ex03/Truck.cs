using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class Truck : Vehicle
    {
        protected const int k_NumberOfWheels = 12;
        internal static float s_MaximumAirPressure = 34;
        internal static float s_LitersFuelTank = 160;
        protected float m_MaximumCarryingWeight;
        protected bool v_IsCarryDangerousMaterials;

        public Truck(string i_VehicleModelName, string i_VehicleLicenseNumber,
                        float i_VehicleEnergyPercent, eNumberOfWheels i_VehicleNumberOfWheels,
                        string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, float i_MaximumCarryWeight, bool i_IsCarryDangerousMaterials) :
            base(i_VehicleModelName, i_VehicleLicenseNumber, i_VehicleEnergyPercent,
                          i_VehicleNumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure)
        {
            m_MaximumCarryingWeight = i_MaximumCarryWeight;
            v_IsCarryDangerousMaterials = i_IsCarryDangerousMaterials;
            m_NumberOfWheels = eNumberOfWheels.Twelve;
        }

        public float TruckMaximumCarryingWeight
        {
            get { return m_MaximumCarryingWeight; }
            set { m_MaximumCarryingWeight = value; }
        }

        public bool IsCarryDangerousMaterials
        {
            get { return v_IsCarryDangerousMaterials; }
            set { v_IsCarryDangerousMaterials = value; }
        }
    }
}
