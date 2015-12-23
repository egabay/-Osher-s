using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace A16_Ex03
{
    internal abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergyPercent;
        protected Wheel m_WheelCollection; 
        protected int m_NumberOfWheels; 

        public string VehicleModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string VehicleLicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float VehicleEnergyPercent
        {
            get { return m_RemainingEnergyPercent;}
            set { m_RemainingEnergyPercent = value; }
        }

        public int VehicleNumberOfWheels
        {
            get { return m_NumberOfWheels; }
            set { m_NumberOfWheels = value; }
        }

        public Vehicle(string i_VehicleModelName, string i_VehicleLicenseNumber, float i_VehicleEnergyPercent,
            int i_VehicleNumberOfWheels, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            m_ModelName = i_VehicleModelName;
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_RemainingEnergyPercent = i_VehicleEnergyPercent;
            m_NumberOfWheels = i_VehicleNumberOfWheels; 
            m_WheelCollection = new Wheel(i_WheelManufacturerName, i_CurrentAirPressure);
            m_WheelCollection.WheelMaximumAirPressure = i_MaximumAirPressure; 
        }
        
        public Wheel VehicleWheelCollection
        {
            get { return m_WheelCollection; }
            set { m_WheelCollection = value; }
        }

        protected internal virtual void RefuelingVehicle(float i_LitersToFool, Enums.eFuelType i_TFuelType) { }
    }
}
