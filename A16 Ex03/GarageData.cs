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
            const bool v_isNotContained = true;
            bool retVal = v_isNotContained;
            if (m_LicenseToVehicle.ContainsKey(i_VehicleToAdd.VehicleLicenseNumber))
            {
                i_VehicleOwnerToAdd.VehicleStatus = eVehicleStatus.InRepair;
                retVal = !v_isNotContained;
            }
            else
            {
                m_LicenseToOwner.Add(i_VehicleToAdd.VehicleLicenseNumber, i_VehicleOwnerToAdd);
                m_LicenseToVehicle.Add(i_VehicleToAdd.VehicleLicenseNumber, i_VehicleToAdd);
                i_VehicleOwnerToAdd.VehicleStatus = eVehicleStatus.InRepair;
            }

            return retVal;
        }

        public string GetAllLicenseNumbers(object i_Status = null)
        {
            StringBuilder retVal = new StringBuilder();
            foreach (KeyValuePair<string, VehicleOwner> item in m_LicenseToOwner)
            {
                if (i_Status != null)
                {
                    if (item.Value.VehicleStatus == (eVehicleStatus)i_Status)
                    {
                        retVal.Append(item.Key).AppendLine();
                    }
                }
                else
                {
                    retVal.Append(item.Key).AppendLine();
                }
            }

            if (retVal.ToString() == string.Empty)
            {
                if (i_Status != null)
                {
                    retVal.Append("There is no vehicles in the garage").AppendLine();
                }
                else
                {
                    retVal.Append("There is no vehicles in the garage in this status").AppendLine();
                }
            }

            return retVal.ToString();
        }

        public string GetDetails(string i_LicenseNumber)
        {
            Vehicle innerVehicle;
            VehicleOwner innerOwner;
            StringBuilder retVal = new StringBuilder();
            if (m_LicenseToVehicle.TryGetValue(i_LicenseNumber, out innerVehicle))
            {
                retVal.Append(innerVehicle.ToString());
                if (m_LicenseToOwner.TryGetValue(i_LicenseNumber, out innerOwner))
                {
                    retVal.Append(innerOwner.ToString());
                }
            }
            else
            {
                retVal.Append("The vehicle license number entered is not exists");
            }

            return retVal.ToString();
        }

        public bool FillEnergyResource(string i_LicenseNumber, float i_AmountToFill, object i_FuelTypeIfFuelEngine = null)
        {
            const bool v_isNotContained = true;
            bool retVal = v_isNotContained;
            Vehicle innerVehicle;
            if (m_LicenseToVehicle.TryGetValue(i_LicenseNumber, out innerVehicle))
            {
                try
                {
                    if (innerVehicle.Engine is ElectricEngine)
                    {
                        ((ElectricEngine)innerVehicle.Engine).RefillEnergyStorage(i_AmountToFill);
                    }
                    else
                    {
                        ((FuelEngine)innerVehicle.Engine).RefillEnergyStorage(i_AmountToFill, (eFuelType)i_FuelTypeIfFuelEngine);
                    }

                    innerVehicle.VehicleEnergyPercent = (innerVehicle.Engine.CurrentEnergyStorageStatus / innerVehicle.Engine.MaximumEnergyStorageCapacity) * 100;
                }
                catch (ValueOutOfRangeException e)
                {
                    throw e;
                }
                catch (ArgumentException e)
                {
                    throw e;
                }
            }
            else
            {
                retVal = !v_isNotContained;
            }

            return retVal;
        }

        public bool IsFuelVehicle(string i_LicenseNumber)
        {
            const bool v_IsFuelVehicle = true;
            bool retVal = v_IsFuelVehicle;
            Vehicle innerVehicle;
            if (m_LicenseToVehicle.TryGetValue(i_LicenseNumber, out innerVehicle))
            {
                if (innerVehicle.Engine is ElectricEngine)
                {
                    retVal = !v_IsFuelVehicle;
                }
            }

            return retVal;
        }

        public bool ChangeStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            const bool v_IsInTheGarage = true;
            bool retVal = v_IsInTheGarage;
            VehicleOwner innerOwner;
            if (m_LicenseToOwner.TryGetValue(i_LicenseNumber, out innerOwner))
            {
                innerOwner.VehicleStatus = i_Status;
            }
            else
            {
                retVal = !v_IsInTheGarage;
            }

            return retVal;
        }

        public bool MaximizeWheelPressure(string i_LicenseNumber)
        {
            const bool v_IsInTheGarage = true;
            bool retVal = v_IsInTheGarage;
            Vehicle innerVehicle;
            if (m_LicenseToVehicle.TryGetValue(i_LicenseNumber, out innerVehicle))
            {
                innerVehicle.VehicleWheelCollection.WheelCurrentAirPressure =
                    innerVehicle.VehicleWheelCollection.WheelMaximumAirPressure;
            }
            else
            {
                retVal = !v_IsInTheGarage;
            }

            return retVal;
        }
    }
}
