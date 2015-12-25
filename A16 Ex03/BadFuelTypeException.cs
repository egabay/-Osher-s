using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class BadFuelTypeException : Exception
    {
        private eFuelType m_FuelTypeToFill;
        private eFuelType m_FuelTypeRequired;
        public BadFuelTypeException(eFuelType i_FuelTypeToFill, eFuelType i_FuelTypeRequired)
            : base(String.Format("Error occured while trying to fill Fuel Type : {0} Into {1} Tank", i_FuelTypeToFill, i_FuelTypeRequired))
        {
            m_FuelTypeRequired = i_FuelTypeRequired;
            m_FuelTypeToFill = i_FuelTypeToFill;
        }
        public eFuelType FuelTypeToFill
        {
            get { return m_FuelTypeToFill; }
        }
        public eFuelType FuelTypeRequired
        {
            get { return m_FuelTypeRequired; }
        }
    }
}
