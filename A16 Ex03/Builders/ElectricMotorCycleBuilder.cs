using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class ElectricMotorCycleBuilder : VehicleBuilder
    {
        public ElectricMotorCycleBuilder()
        {
            m_Vehicle = new MotorCycle();
        }
        public ElectricMotorCycleBuilder(eLicenseType i_LicenseType, int i_EngineSize)
        {
            m_Vehicle = new MotorCycle();
            MotorCycle motor = new MotorCycle();
            motor = (MotorCycle)m_Vehicle;
            motor.EngineSize = i_EngineSize;
            motor.LicenseType = i_LicenseType;
        }
        public override void BuildEngine(float i_CurrentEnergyStorageStatus)
        {
            m_Vehicle.Engine = new ElectricEngine(i_CurrentEnergyStorageStatus, 2.4f);
        }

        public override void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_Vehicle.VehicleWheelCollection = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            m_Vehicle.VehicleNumberOfWheels = eNumberOfWheels.Two;
            m_Vehicle.VehicleWheelCollection.WheelMaximumAirPressure = 32;
        }
    }
}
