using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace Ex02_New
{
    class RegularMoveCordinates
    {
        Point m_FromLocationCordinates;
        Point m_ToLocationCordinates;

        public RegularMoveCordinates()
        {
            m_FromLocationCordinates = new Point();
            m_ToLocationCordinates = new Point();
        }

        public RegularMoveCordinates(int i_FromXCordinate,int i_FromYCordinate,int i_ToXCordinate,int i_ToYCordinate)
        {
            m_FromLocationCordinates.X = i_FromXCordinate;
            m_FromLocationCordinates.Y = i_FromYCordinate;
            m_ToLocationCordinates.X = i_ToXCordinate;
            m_ToLocationCordinates.Y= i_ToYCordinate;
        }

        public int FromLocationXCordinate
        {
            get { return m_FromLocationCordinates.X; }
            set { m_FromLocationCordinates.X = value; }
        }
        public int FromLocationYCordinate
        {
            get { return m_FromLocationCordinates.Y; }
            set { m_FromLocationCordinates.Y = value; }
        }
        public int ToLocationXCordinate
        {
            get { return m_ToLocationCordinates.X; }
            set { m_ToLocationCordinates.X = value; }
        }
        public int ToLocationYCordinate
        {
            get { return m_ToLocationCordinates.Y; }
            set { m_ToLocationCordinates.Y = value; }
        }
        
    }
}
