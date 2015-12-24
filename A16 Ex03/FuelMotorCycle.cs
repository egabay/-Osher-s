using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class FuelMotorCycle : FuelVehicle
    {
        protected const int k_MotorCycleNumberOfWheels = 2;
        internal static float s_MaximumAirPressure = 32;
        internal static Enums.eFuelType s_MotorCycleFuelType = Enums.eFuelType.Octan96;
        internal static float s_LitersFuelTank = 6;
        protected Enums.eLicenseType m_MotorCycleLicenseType;
        protected int m_MotorCycleEngineCapacityByCm;

        public FuelMotorCycle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercent,
            string i_WheelManufacturName, float i_CurrentAirPressure, float i_CurrentFuelAmountByLiters,
            Enums.eLicenseType m_LicenseType, int m_EngineCapacityByCm) :
                base(
                i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, k_MotorCycleNumberOfWheels,
                i_WheelManufacturName,
                i_CurrentAirPressure, s_MaximumAirPressure, s_MotorCycleFuelType, i_CurrentFuelAmountByLiters,
                s_LitersFuelTank)
        {
            m_MotorCycleLicenseType = m_LicenseType;
            m_MotorCycleEngineCapacityByCm = m_EngineCapacityByCm;
        }

        public Enums.eLicenseType eMotorCycleLicenseType
        {
            get { return m_MotorCycleLicenseType; }
            set { m_MotorCycleLicenseType = value; }
        }

        public int MotorCycleEngineCapacityByCm
        {
            get { return m_MotorCycleEngineCapacityByCm; }
            set { m_MotorCycleEngineCapacityByCm = value; }
        }
    }
}
