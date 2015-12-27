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
                i_VehicleOwnerToAdd.VehicleStatus = eVehicleStatus.InRepair;
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
                retVal = "The vehicle license number entered is not exists";
            }
            return retVal;

        }
        public void FillEnergyResource(string i_LicenseNumber,float i_AmountToFill,object i_FuelTypeIfFuelEngine=null)
        {
            Vehicle innerVehicle;
            if(m_LicenseToVehicle.TryGetValue(i_LicenseNumber,out innerVehicle))
            {
               if(innerVehicle.Engine is ElectricEngine)
               {
                   ((ElectricEngine)innerVehicle.Engine).RefillEnergyStorage(i_AmountToFill);
               }
               else
               {
                   ((FuelEngine)innerVehicle.Engine).RefillEnergyStorage(i_AmountToFill, (eFuelType)i_FuelTypeIfFuelEngine);
               }
            }

        }
    }
}
