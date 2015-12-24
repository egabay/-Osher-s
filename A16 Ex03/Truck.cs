using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class Truck : Vehicle
    {
        protected const int k_NumberOfWheels = 12;
        internal static float s_MaximumAirPressure = 34; 
        internal static float s_LitersFuelTank = 160;
        protected float m_MaximumCarryingWeight;
        protected bool m_IsCarryDangerousMaterials;


        
        public float TruckMaximumCarryingWeight
        {
            get { return m_MaximumCarryingWeight; }
            set { m_MaximumCarryingWeight = value; }
        }

        public bool IsCarryDangerousMaterials
        {
            get { return m_IsCarryDangerousMaterials; }
            set { m_IsCarryDangerousMaterials = value; }
        }
    }
}
