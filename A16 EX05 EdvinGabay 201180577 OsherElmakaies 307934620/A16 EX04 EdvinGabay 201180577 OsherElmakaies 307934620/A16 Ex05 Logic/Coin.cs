using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05
{
    internal class Coin
    {
        private ePlayer m_CoinType;

        public Coin(ePlayer i_Type)
        {
            m_CoinType = i_Type;
        }

        public ePlayer PlayerCoin
        {
            get { return m_CoinType; }
            set { m_CoinType = value; }
        }
    }
}
