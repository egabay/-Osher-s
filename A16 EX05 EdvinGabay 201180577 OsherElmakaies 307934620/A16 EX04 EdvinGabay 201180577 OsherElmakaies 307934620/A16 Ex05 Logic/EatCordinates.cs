using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ex05
{
    public class EatCordinates : MoveCordinates
    {
        private Point m_EatenPlace;

        public EatCordinates()
        {
            m_EatenPlace= new Point();
        }

        public EatCordinates(int i_FromRowCordinate, int i_FromLineCordinate, int i_ToRowCordinate, int i_ToLineCordinate, int i_EatenRowPlace, int i_EatenLinePlace)
        {
            m_FromLocationCordinates.X = i_FromRowCordinate;
            m_FromLocationCordinates.Y = i_FromLineCordinate;
            m_ToLocationCordinates.X = i_ToRowCordinate;
            m_ToLocationCordinates.Y = i_ToLineCordinate;
            m_EatenPlace.X = i_EatenRowPlace;
            m_EatenPlace.Y = i_EatenLinePlace;
        }

        public int EatenRowXCordinate
        {
            get { return m_EatenPlace.X; }
            set { m_EatenPlace.X = value; }
        }

        public int EatenLineYCordinate
        {
            get { return m_EatenPlace.Y; }
            set { m_EatenPlace.Y = value; }
        }
    }
}
