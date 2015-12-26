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

        public void WeightingWheel(float i_AmountOfAirPressureToAdd)
        {
            float minAirPressure = 0;
            if ((i_AmountOfAirPressureToAdd > 0) && (i_AmountOfAirPressureToAdd <= m_MaximumAirPressure))
            {
                if ((m_CurrentAirPressure + i_AmountOfAirPressureToAdd) <= m_MaximumAirPressure)
                {
                    m_CurrentAirPressure += i_AmountOfAirPressureToAdd;
                }
                else
                {
                    throw new OverEnergyStorageMaxException(i_AmountOfAirPressureToAdd, m_MaximumAirPressure);
                }
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaximumAirPressure, minAirPressure);
            }
        }
    }
}
