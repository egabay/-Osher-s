using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity)
            : base(i_CurrentEnergyStorageStatus, i_MaximumEnergyStorageCapacity)
        {

        }
        public void RefillEnergyStorage(float i_AmountEnergyToFill)
        {
            if ((m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus >= i_AmountEnergyToFill) && (i_AmountEnergyToFill >= 0))
            {
                m_CurrentEnergyStorageStatus += i_AmountEnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(i_AmountEnergyToFill, m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus);
            }
        }
    }
}
