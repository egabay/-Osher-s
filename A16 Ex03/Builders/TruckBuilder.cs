using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class TruckBuilder:VehicleBuilder
    {
        public TruckBuilder()
        {
            m_Vehicle = new Truck();
        }
        public override void BuildEngine(float i_CurrentEnergyStorageStatus)
        {
            m_Vehicle.Engine = new FuelEngine(i_CurrentEnergyStorageStatus, 160f, eFuelType.Soler);
        }

        public override void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_Vehicle.VehicleWheelCollection = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            m_Vehicle.VehicleNumberOfWheels = eNumberOfWheels.Twelve;
            m_Vehicle.VehicleWheelCollection.WheelMaximumAirPressure = 34;
        }
    }
}
