using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class ElectricCarBuilder : VehicleBuilder
    {
        public ElectricCarBuilder()
        {

        }
        public ElectricCarBuilder(eColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        {
            m_Vehicle = new Car();
            Car motor = new Car();
            motor = (Car)m_Vehicle;
            motor.Color= i_CarColor;
            motor.NumberOfDoors = i_NumberOfDoors;
        }
        public override void BuildEngine(float i_CurrentEnergyStorageStatus)
        {
            m_Vehicle.Engine = new ElectricEngine(i_CurrentEnergyStorageStatus, 2.8f);
        }
        public override void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_Vehicle.VehicleWheelCollection = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            m_Vehicle.VehicleNumberOfWheels = eNumberOfWheels.Four;
            m_Vehicle.VehicleWheelCollection.WheelMaximumAirPressure = 29;
        }
        
    }
}
