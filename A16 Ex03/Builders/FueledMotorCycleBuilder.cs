using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Builders
{
    public class FueledMotorCycleBuilder : VehicleBuilder
    {
        public FueledMotorCycleBuilder()
        {

        }
        public FueledMotorCycleBuilder(eLicenseType i_LicenseType, int i_EngineSize)
        {
            m_Vehicle = new MotorCycle();
            MotorCycle motor = new MotorCycle();
            motor = (MotorCycle) m_Vehicle;
            motor.EngineSize = i_EngineSize;
            motor.LicenseType = i_LicenseType;
        }

        public override void BuildEngine(float i_CurrentEnergyStorageStatus)
        {
            MotorCycle motorCycle = (MotorCycle) m_Vehicle;
            motorCycle.Engine = new FuelEngine(i_CurrentEnergyStorageStatus, 6f, eFuelType.Octan96);
        }

        public override void BuildWheels(string i_WheelManufacturerName, float i_WheelCurrentAirPressure)
        {
            m_Vehicle.VehicleWheelCollection = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure);
            m_Vehicle.VehicleNumberOfWheels = eNumberOfWheels.Two;
            m_Vehicle.VehicleWheelCollection.WheelMaximumAirPressure = 32;
        }
    }
}
