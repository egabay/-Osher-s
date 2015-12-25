using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A,
        A1,
        A4,
        C
    }

    public class MotorCycle : Vehicle
    {
        private Engine m_Engine;
        private int m_EngineSize;
        private eLicenseType m_LicenseType;
        protected const int k_MotorCycleNumberOfWheels = 2;
        internal static float s_MaximumAirPressure = 32;
        internal static float s_LitersFuelTank = 6;
  
        public MotorCycle(string i_VehicleModelName, string i_VehicleLicenseNumber,
                        float i_VehicleEnergyPercent, eNumberOfWheels i_VehicleNumberOfWheels,
                        string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, eLicenseType i_LicenseType, int i_EngineSize) :
            base(i_VehicleModelName, i_VehicleLicenseNumber, i_VehicleEnergyPercent,
                          i_VehicleNumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure)
        {
            m_LicenseType = i_LicenseType;
            m_EngineSize = i_EngineSize;
            m_NumberOfWheels = eNumberOfWheels.Two;
        }
        protected override string GetAttributes()
        {
            string retVal;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("License Type : {0}, Engine Size : {1}", LicenseType.ToString(), EngineSize);
            retVal = builder.ToString();
            return retVal;
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
        }
    }

}
