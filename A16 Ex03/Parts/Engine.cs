using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyStorageStatus;
        protected float m_MaximumEnergyStorageCapacity;

        public float CurrentEnergyStorageStatus
        {
            get { return m_CurrentEnergyStorageStatus; }
        }

        public float MaximumEnergyStorageCapacity
        {
            get { return m_MaximumEnergyStorageCapacity; }
        }

        public Engine(float i_CurrentEnergyStorageStatus, float i_MaximumEnergyStorageCapacity)
        {
            m_CurrentEnergyStorageStatus = i_CurrentEnergyStorageStatus;
            m_MaximumEnergyStorageCapacity = i_MaximumEnergyStorageCapacity;
        }
    }
}
