using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    enum eVehicleStatus
    {
        InRepair,
        Fixed,
        Paid
    }

    public class VehicleOwner
    {
        eVehicleStatus m_VehicleStatus;


        public VehicleOwner()
        {

        }

        internal eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

    }
}
