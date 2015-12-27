using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class FueledCarBuilder : VehicleBuilder
    {
        public FueledCarBuilder()
        {
            m_Vehicle = new Car();
        }

        public override void BuildEngine(float i_CurrentEnergyStorageStatus)
        {
            m_Vehicle.Engine = new FuelEngine(i_CurrentEnergyStorageStatus, 42f, eFuelType.Octan98);
        }

        public override void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_Vehicle.VehicleWheelCollection = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            m_Vehicle.VehicleNumberOfWheels = eNumberOfWheels.Four;
            m_Vehicle.VehicleWheelCollection.WheelMaximumAirPressure = 29;
        }
    }
}
