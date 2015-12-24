using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class OverRefuelException : Exception
    {
        private float m_LitersToRefuel;
        private Enums.eFuelType m_FuelType;

        public OverRefuelException(float i_LitersToFool, Enums.eFuelType i_FuelType) :
            base(
            string.Format("Error occured while trying to refuel {0} into fuel type {1}", i_LitersToFool, i_FuelType))
        {
            m_LitersToRefuel = i_LitersToFool;
            m_FuelType = i_FuelType;
        }

        public float LitersToRefuel
        {
            get { return m_LitersToRefuel; }
        }

        public Enums.eFuelType FuelType
        {
            get { return m_FuelType; }
        }
    }
}
