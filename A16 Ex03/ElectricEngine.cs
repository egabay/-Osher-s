using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity)
            : base(i_CurrentEnergyStorageStatus, i_MaximumEnergyStorageCapacity)
        {

        }
        public void RefillEnergyStorage(float i_AmountEnergyToFill)
        {
            if (m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus < i_AmountEnergyToFill)
            {
                throw new OverEnergyStorageMaxException(i_AmountEnergyToFill, m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus);
            }
            m_CurrentEnergyStorageStatus += i_AmountEnergyToFill;
        }
    }
}
