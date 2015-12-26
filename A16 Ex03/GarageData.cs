using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageData
    {
        Dictionary<string, Vehicle> m_LicenseToVehicle = new Dictionary<string, Vehicle>();
        Dictionary<string, VehicleOwner> m_LicenseToOwner = new Dictionary<string, VehicleOwner>();

        public bool AddNewVehicle(Vehicle i_VehicleToAdd, VehicleOwner i_VehicleOwnerToAdd)
        {
            const bool isNotContained = true;
            bool retVal = isNotContained;
            if (m_LicenseToVehicle.ContainsKey(i_VehicleToAdd.VehicleLicenseNumber))
            {
                i_VehicleOwnerToAdd.VehicleStatus=eVehicleStatus.InRepair;
                retVal = !isNotContained;
            }
            else
            {
                m_LicenseToOwner.Add(i_VehicleToAdd.VehicleLicenseNumber, i_VehicleOwnerToAdd);
                m_LicenseToVehicle.Add(i_VehicleToAdd.VehicleLicenseNumber, i_VehicleToAdd);
            }
            return retVal;
        }

        public string GetDetails(string i_LicenseNumber)
        {
            Vehicle innerVehicle;
            string retVal;
            if (m_LicenseToVehicle.TryGetValue(i_LicenseNumber, out innerVehicle))
            {
                retVal = innerVehicle.ToString();
            }
            else
            {
                retVal = "The vehicle license number Entered does not exist";
            }
            return retVal;

        }
    }
}
