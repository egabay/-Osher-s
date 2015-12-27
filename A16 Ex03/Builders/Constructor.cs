using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class Constructor
    {
        public Constructor()
        {
        }
        public Vehicle Construct(VehicleBuilder i_VehicleBuilder, string i_ModelName, string i_LicenseNumber,float i_CurrentEnergyStorageStatus,
                                string i_WheelManufacturerName, float i_WheelCurrentAirPressure, object i_FirstProperty, object i_SecondProperty)
        {
            i_VehicleBuilder.BuildModelName(i_ModelName);
            i_VehicleBuilder.BuildLicenseNumber(i_LicenseNumber);
            i_VehicleBuilder.BuildEngine(i_CurrentEnergyStorageStatus);
            i_VehicleBuilder.BuildWheels(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            i_VehicleBuilder.BuildFirstDifferentProperty(i_FirstProperty);
            i_VehicleBuilder.BuildSecondDifferentProperty(i_SecondProperty);
            return i_VehicleBuilder.Vehicle;
        }
    }
}
