using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    internal class Wheel
    {
        protected string m_ManufacturerName;
        protected float m_CurrentAirPressure;
        protected float m_MaximumAirPressure;

        public string WheelManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float WheelCurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }

        }

        public float WheelMaximumAirPressure
        {
            get { return m_MaximumAirPressure; }
            set { m_MaximumAirPressure = value; }
        }

        public Wheel(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_ManufacturerName = i_WheelManufacturerName;
            m_CurrentAirPressure = WheelCurrentAirPressure;
        }

        /// Need to add a catch for this method
        public void WeightingWheel(float i_AmountOfPressure)
        {
            try
            {
                bool newAirPressue = (m_CurrentAirPressure += i_AmountOfPressure) <= m_MaximumAirPressure;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
