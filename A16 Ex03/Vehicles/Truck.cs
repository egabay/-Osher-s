using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const int k_NumberOfWheels = 12;
        internal static float s_MaximumAirPressure = 34;
        internal static float s_LitersFuelTank = 160;
        protected float m_MaximumCarryingWeight;
        protected bool v_IsCarryDangerousMaterials;

        public Truck()
        {
        }

        protected override string GetAttributes()
        {
            string retVal;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Maximum Carry Weight : {0}, Carry Dungerous Materials : {1}", m_MaximumCarryingWeight, v_IsCarryDangerousMaterials.ToString());
            retVal = builder.ToString();
            return retVal;
        }

        public float TruckMaximumCarryingWeight
        {
            get { return m_MaximumCarryingWeight; }
            set { m_MaximumCarryingWeight = value; }
        }

        public bool IsCarryDangerousMaterials
        {
            get { return v_IsCarryDangerousMaterials; }
            set { v_IsCarryDangerousMaterials = value; }
        }

        public sealed override object FirstDifferentProperty
        {
            get { return v_IsCarryDangerousMaterials; }
            set { v_IsCarryDangerousMaterials = (bool)value; }
        }

        public sealed override object SecondDifferentProperty
        {
            get { return m_MaximumCarryingWeight; }
            set { m_MaximumCarryingWeight = (float)value; }
        }
    }
}
