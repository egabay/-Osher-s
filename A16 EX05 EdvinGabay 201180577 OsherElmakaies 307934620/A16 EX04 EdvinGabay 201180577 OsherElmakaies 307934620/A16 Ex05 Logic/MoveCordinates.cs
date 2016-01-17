using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 

namespace Ex05
{
    public class MoveCordinates
    {
        protected Point m_FromLocationCordinates;
        protected Point m_ToLocationCordinates;

        public MoveCordinates()
        {
            m_FromLocationCordinates = new Point();
            m_ToLocationCordinates = new Point();
        }

        public MoveCordinates(int i_FromRowCordinate, int i_FromLineCordinate, int i_ToRowCordinate, int i_ToLineCordinate)
        {
            m_FromLocationCordinates.X = i_FromRowCordinate;
            m_FromLocationCordinates.Y = i_FromLineCordinate;
            m_ToLocationCordinates.X = i_ToRowCordinate;
            m_ToLocationCordinates.Y = i_ToLineCordinate;
        }

        public int FromRowXCordinate
        {
            get { return m_FromLocationCordinates.X; }
            set { m_FromLocationCordinates.X = value; }
        }

        public int FromLineYCordinate
        {
            get { return m_FromLocationCordinates.Y; }
            set { m_FromLocationCordinates.Y = value; }
        }

        public int ToRowXCordinate
        {
            get { return m_ToLocationCordinates.X; }
            set { m_ToLocationCordinates.X = value; }
        }

        public int ToLineYCordinate
        {
            get { return m_ToLocationCordinates.Y; }
            set { m_ToLocationCordinates.Y = value; }
        }
    }
}
