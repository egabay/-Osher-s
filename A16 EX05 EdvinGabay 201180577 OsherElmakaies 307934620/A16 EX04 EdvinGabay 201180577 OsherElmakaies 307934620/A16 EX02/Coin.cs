using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02_New
{
    internal class Coin
    {
        private ePlayer m_PlayerCoin;

        public Coin()
        {

        }
        public ePlayer PlayerCoin
        {
            get { return m_PlayerCoin; }
            set { m_PlayerCoin = value; }
        }

    }
}
