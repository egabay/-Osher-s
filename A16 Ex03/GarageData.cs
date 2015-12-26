using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GarageData
    {
        Dictionary<string,Vehicle> m_LicenseToVehicle=new Dictionary<string,Vehicle>();
        Dictionary<string,VehicleOwner> m_LicenseToOwner=new Dictionary<string,VehicleOwner>();

        public bool AddNewVehicle(Vehicle i_VehicleToAdd,VehicleOwner i_VehicleOwnerToAdd)
        {
            return true;
        }
    }
}
