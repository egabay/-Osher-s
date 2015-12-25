using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format("Your amount should be between {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxToFill
        {
            get { return m_MaxValue; }
        }

        public float MinToFill
        {
            get { return m_MinValue; }
        }
    }
}
