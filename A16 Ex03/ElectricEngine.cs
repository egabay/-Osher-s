using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class ElectricEngine
    {
        float m_TimeLeftToZeroCharge;
        float m_MaxBatteryHours;

        public ElectricEngine()
        {
            
        }

        public void ChargeBattery(float i_AmountOfTimeToCharge)
        {
            if (m_MaxBatteryHours - m_TimeLeftToZeroCharge < i_AmountOfTimeToCharge)
            {
                throw new OverChargedException(i_AmountOfTimeToCharge, m_MaxBatteryHours - m_TimeLeftToZeroCharge);
            }
             m_TimeLeftToZeroCharge += i_AmountOfTimeToCharge;
            
        }
    }
}
