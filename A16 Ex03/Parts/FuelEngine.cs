using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        None = 0,
        Octan98,
        Octan96,
        Octan95,
        Soler
    }

    public class FuelEngine : Engine
    {
        eFuelType m_FuelType;
        public FuelEngine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity, eFuelType i_FuelType)
            : base(i_CurrentEnergyStorageStatus, i_MaximumEnergyStorageCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public void RefillEnergyStorage(float i_AmountEnergyToFill,eFuelType i_FuelType)
        {
            if((eFuelType)i_FuelType==m_FuelType)
            {
                if((i_AmountEnergyToFill<=m_MaximumEnergyStorageCapacity-m_CurrentEnergyStorageStatus)&&(i_AmountEnergyToFill>=0))
                {
                    m_CurrentEnergyStorageStatus += i_AmountEnergyToFill;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_AmountEnergyToFill, m_MaximumEnergyStorageCapacity - m_CurrentEnergyStorageStatus);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Error trying to Fill {0} Into {1} Tank", (eFuelType)i_FuelType, m_FuelType));
            }
        }
        public override string ToString()
        {
            return (String.Format("Current Fuel status : {1} , Maximum Fuel Capacity : {2},Fuel type :{3}",
                m_CurrentEnergyStorageStatus, m_MaximumEnergyStorageCapacity,m_FuelType));
        }
    }
}
