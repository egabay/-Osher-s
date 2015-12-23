using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    internal abstract class FuelVehicle : Vehicle
    {
        protected Enums.eFuelType m_FuelType;
        protected float m_CurrentFuelAmountByLiters;
        protected float m_MaximunFuelAmountByLiters;

        public Enums.eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public float CurrentFuelAmountByLiters
        {
            get { return m_CurrentFuelAmountByLiters; }
            set { m_CurrentFuelAmountByLiters = value; }
        }

        public float MaximunFuelAmountByLiters
        {
            get { return m_MaximunFuelAmountByLiters; }
            set { m_MaximunFuelAmountByLiters = value; }
        }

        public FuelVehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercent,
            int i_NumberOfWheel, string i_WheelManufacturName, float i_CurrentAirPressure, float i_MaximumAirPressure,
            Enums.eFuelType i_FuleType, float i_CurrentFuelAmountByLiters, float i_MaximunFuelAmountByLiters)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, i_NumberOfWheel, i_WheelManufacturName,
                i_CurrentAirPressure, i_MaximumAirPressure)
        {
            m_FuelType = i_FuleType;
            m_CurrentFuelAmountByLiters = i_CurrentFuelAmountByLiters;
            m_MaximunFuelAmountByLiters = i_MaximunFuelAmountByLiters; 
        }

        protected internal override void RefuelingVehicle(float i_LitersToFool, Enums.eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType || (m_CurrentFuelAmountByLiters + i_LitersToFool) <= m_MaximunFuelAmountByLiters)
            {
                throw new OverRefuelException(i_LitersToFool, i_FuelType);
            }
            m_CurrentFuelAmountByLiters += i_LitersToFool;
        }

         
    }
}
