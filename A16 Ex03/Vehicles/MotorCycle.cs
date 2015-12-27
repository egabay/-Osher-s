using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        None = 0,
        A,
        A1,
        A4,
        C
    }

    internal class MotorCycle : Vehicle
    {
        private int m_EngineSize=0;
        private eLicenseType m_LicenseType;
        protected const int k_MotorCycleNumberOfWheels = 2;
        internal static float s_MaximumAirPressure = 32;
        internal static float s_LitersFuelTank = 6;

        public MotorCycle()
        {

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
            set { m_LicenseType = value; }
        }

        public int EngineSize
        {      
            get { return m_EngineSize; }
            set { m_EngineSize = value; }
        }
        public sealed override object FirstDifferentProperty
        {
            get{ return m_LicenseType; }
            set{ m_LicenseType = (eLicenseType)value; }
        }
        public sealed override object SecondDifferentProperty
        {
            get { return m_EngineSize; }
            set { m_EngineSize = (int)value; }
        }
    }

}
