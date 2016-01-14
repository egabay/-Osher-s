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

        public EatCordinates(int i_XCordinate, int i_YCordinate)
        {
            m_EatenPlace.X = i_XCordinate;
            m_EatenPlace.Y = i_YCordinate;
        }

        public int XCordinate
        {
            get { return m_EatenPlace.X; }
            set { m_EatenPlace.X = value; }
        }

        public int YCordinate
        {
            get { return m_EatenPlace.Y; }
            set { m_EatenPlace.Y = value; }
        }
    }
}
