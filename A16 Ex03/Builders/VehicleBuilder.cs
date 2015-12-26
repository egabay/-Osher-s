using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class VehicleBuilder
    {
        protected Vehicle m_Vehicle;

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }
        public void BuildModelName(string i_ModelName)
        {
            m_Vehicle.VehicleModelName = i_ModelName;
        }
        public void BuildLicenseNumber(string i_LicenseNumber)
        {
            m_Vehicle.VehicleLicenseNumber = i_LicenseNumber;
        }
        public void BuildEnergyLeftPercentage(float i_EnergyLeftPercentage)
        {
            m_Vehicle.VehicleEnergyPercent = i_EnergyLeftPercentage;
        }
        public abstract void BuildEngine(float i_CurrentEnergyStorageStatus);
        public abstract void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure);
        public void BuildFirstDifferentProperty(object i_Property)
        {
            m_Vehicle.FirstDifferentProperty = i_Property;
        }
        public void BuildSecondDifferentProperty(object i_Property)
        {
            m_Vehicle.SecondDifferentProperty = i_Property;
        }
    }

}
