﻿using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    class OverChargedException:Exception
    {
        private float m_ChargeAmount;
        private float m_MaxToCharge;
        public OverChargedException(float i_AmountToCharge,float i_MaxToCharge):
                                    base(String.Format("Error occured while trying to fill {0} into max of {1} battery to charge ",
                                                                                      i_AmountToCharge,i_MaxToCharge))
        {
            m_ChargeAmount = i_AmountToCharge;
            m_MaxToCharge = i_MaxToCharge;
        }

        public float MaxToCharge
        {
            get { return m_MaxToCharge; }
        }
        public float ChargeAmount
        {
            get { return m_ChargeAmount;}
        }
    }
}
