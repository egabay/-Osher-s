using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    enum eLicenseType
    {
        A,
        A1,
        A4,
        C
    }

    class MotorCycle : Vehicle
    {
        private Engine m_Engine;
        private int m_EngineSize;
        private eLicenseType m_LicenseType;
        public MotorCycle(string i_VehicleModelName, string i_VehicleLicenseNumber, 
                        float i_VehicleEnergyPercent, int i_VehicleNumberOfWheels, 
                        string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure,eLicenseType i_LicenseType,int i_EngineSize) : 
                    base(i_VehicleModelName, i_VehicleLicenseNumber, i_VehicleEnergyPercent,    
                        i_VehicleNumberOfWheels, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure)
        {
            m_LicenseType = i_LicenseType;
            m_EngineSize = i_EngineSize;
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType;}
        }

        public int EngineSize
        {
            get { return m_EngineSize;}
        }
    }

}
