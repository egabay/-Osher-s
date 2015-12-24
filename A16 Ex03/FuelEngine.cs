using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    enum eFuelType
    {
        Octan98,
        Octan96,
        Octan95,
        Soler
    }
    class FuelEngine : Engine
    {
        eFuelType m_FuelType;
        public FuelEngine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity, eFuelType i_FuelType)
            : base(i_CurrentEnergyStorageStatus, i_MaximumEnergyStorageCapacity)
        {
            m_FuelType = i_FuelType;
        }
        public void RefillEnergyStorage(float i_AmountEnergyToFill,eFuelType i_FuelType)
        {
            if(i_FuelType==m_FuelType)
            {
                if(i_AmountEnergyToFill<=m_MaximumEnergyStorageCapacity-m_CurrentEnergyStorageStatus)
                {
                    m_CurrentEnergyStorageStatus += i_AmountEnergyToFill;
                }
                else
                {
                    throw new OverEnergyStorageMaxException(i_AmountEnergyToFill, m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus);
                }
            }
            else
            {
                throw new BadFuelTypeException(i_FuelType, m_FuelType);
            }
        }
    }
}
