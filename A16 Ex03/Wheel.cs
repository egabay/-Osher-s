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

        public string ManufacturerNameWheel
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressureWheel
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }

        }

        public float MaximumAirPressureWheel
        {
            get { return m_MaximumAirPressure; }
            set { m_MaximumAirPressure = value; }
        }

        public Wheel(string i_ManufacturerNameWheel, float i_CurrentAirPressureWheel)
        {
            m_ManufacturerName = i_ManufacturerNameWheel;
            m_CurrentAirPressure = CurrentAirPressureWheel;
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
