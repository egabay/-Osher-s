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
            int i_NumberOfWheel, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure,
            Enums.eFuelType i_FuleType, float i_CurrentFuelAmountByLiters, float i_MaximunFuelAmountByLiters)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercent, i_NumberOfWheel, i_ManufacturerName,
                i_CurrentAirPressure, i_MaximumAirPressure)
        {
            //Need to add here
        }
    }
}
