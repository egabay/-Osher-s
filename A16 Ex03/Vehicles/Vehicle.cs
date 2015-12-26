using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eNumberOfWheels
    {
        Two,
        Four,
        Twelve
    }
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergyPercent;
        protected Wheel m_WheelCollection;
        protected eNumberOfWheels m_NumberOfWheels;
        private Engine m_Engine;
        private object m_FirstProperty;
        private object m_SecondProperty;

        public abstract object FirstDifferentProperty
        {
            get;
            set;
        }
        public abstract object SecondDifferentProperty
        {
            get;
            set;
        }


        public Vehicle()
        {
        }
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
            get { return m_RemainingEnergyPercent; }
            set { m_RemainingEnergyPercent = value; }
        }
        public eNumberOfWheels VehicleNumberOfWheels
        {
            get { return m_NumberOfWheels; }
            set { m_NumberOfWheels = value; }
        }
        public Wheel VehicleWheelCollection
        {
            get { return m_WheelCollection; }
            set { m_WheelCollection = value; }
        }
        public override sealed string ToString()
        {
            StringBuilder builder = new StringBuilder();
            string retVal;
            builder.AppendFormat("License Number : {0} ,\n Model Name : {1} ,\n {2} ,\n {3}\n", m_LicenseNumber, m_ModelName, m_WheelCollection.ToString(), this.GetAttributes());
            retVal = builder.ToString();
            return retVal;
        }
        public Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
        protected abstract string GetAttributes();
    }
}
