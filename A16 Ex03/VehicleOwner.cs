using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        None = 0,
        InRepair,
        Paid,
        Fixed
    }

    public class VehicleOwner
    {
        private eVehicleStatus m_VehicleStatus;
        private string m_PhoneNumber;
        private string m_Name;

        public VehicleOwner()
        {
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public override string ToString()
        {
            return (string.Format(",\n Owners Name : {0} , Owners Phone : {1} , Owners Car Status : {2}",
                m_Name, m_PhoneNumber, m_VehicleStatus.ToString()));
        }
    }
}
