using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Builders;

namespace Ex03.ConsoleUI
{
    class GarageProgram
    {

        GarageData m_Data = new GarageData();

        enum eVehicleType
        {
            None = 0,
            FueledMotorCycle,
            ElectricMotorCycle,
        }

        public enum eMenuItem
        {
            None = 0,
            AddNewVehicle,
            ShowVehiclesByLicenseNumber,
            ChangeVehicleStatus,
            FillAirPressure,
            ReFillFuelVehicle,
            ChargeVehicleBattery,
            DisplayVehicleFullDetailsByLicenseNumber,
            Exit
        }

        public enum eVehicleManu
        {
            None = 0,
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public void Run()
        {
            eMenuItem manuItemSelection = eMenuItem.None;
            string strMenSelection = string.Empty;
            string modelName;
            string licenseNumber;
            float currentEnergy;
            float currentEnergyPrecent;
            string manufacturerName;
            float currentAirPressure;
            eLicenseType innerLicenseType;
            VehicleBuilder innerVehicleBuilder;
            VehicleOwner owner = new VehicleOwner();
            while (manuItemSelection != eMenuItem.Exit)
            {
                Console.Clear();
                Console.WriteLine(string.Format(
                    @"Garage Menu :   

1. Add new vehicle to the Garage
2. Display the list of vehicles by ID number < Licence number>
3. Change vehicle status in the Garage
4. Change the air pressure to maximum
5. Refill Fuel Vehicle 
6. Charge battery Vehicle 
7. Display full details on vehicle
8. Exit the Garage Program"));

                strMenSelection = Console.ReadLine();
                manuItemSelection = (eMenuItem) Enum.Parse(typeof (eMenuItem), ValidSelection(strMenSelection, 8));
                switch (manuItemSelection)
                {
                    case eMenuItem.AddNewVehicle:
                        Constructor innerConstructor = new Constructor();
                        Console.Clear();
                        Console.WriteLine(string.Format(
                            @"Vehicle Menu :   

1. Fuel motorcycle
2. Electric motorcycle
3. Fuel car
4. Electric car
5. Truck"));
                        string vehicleSelection = Console.ReadLine();
                        int engineCm;
                        eLicenseType manuLicenseSelection = eLicenseType.None;
                        eVehicleManu manuVehicleSelection;
                        manuVehicleSelection = 
                            (eVehicleManu) Enum.Parse(typeof (eVehicleManu), ValidSelection(vehicleSelection, 5));
                        VehicleDefaultDetails(out modelName, out licenseNumber, out currentEnergyPrecent, 
                                              out currentEnergy, out manufacturerName, out currentAirPressure);
                        switch (manuVehicleSelection)
                        {
                            case eVehicleManu.FuelMotorcycle:
                                ManuMotorCycle(out engineCm, out innerLicenseType);
                                innerVehicleBuilder = new FueledMotorCycleBuilder();
                                CreateNewVehicle(innerConstructor, innerVehicleBuilder, owner, modelName, licenseNumber, 
                                                currentEnergyPrecent, currentEnergy, manufacturerName, currentAirPressure,
                                                innerLicenseType, engineCm);
                                break;
                            case eVehicleManu.ElectricMotorcycle:
                                ManuMotorCycle(out engineCm, out innerLicenseType);
                                innerVehicleBuilder = new ElectricMotorCycleBuilder();
                                CreateNewVehicle(innerConstructor, innerVehicleBuilder, owner, modelName, licenseNumber,
                                                 currentEnergyPrecent, currentEnergy, manufacturerName, currentAirPressure,
                                                 innerLicenseType, engineCm);    
                                break;
                            case eVehicleManu.FuelCar:
                                innerVehicleBuilder = new FueledCarBuilder();
                                CreateNewVehicle(innerConstructor, innerVehicleBuilder, owner, modelName, licenseNumber, currentEnergyPrecent,
                                                 currentEnergy, manufacturerName, currentAirPressure, ColorSelection(), DoorsSelection());
                                break;
                            case eVehicleManu.ElectricCar:
                                innerVehicleBuilder = new ElectricCarBuilder();
                                CreateNewVehicle(innerConstructor, innerVehicleBuilder, owner, modelName, licenseNumber, currentEnergyPrecent,
                                                 currentEnergy, manufacturerName, currentAirPressure, ColorSelection(), DoorsSelection());

                                break;
                            case eVehicleManu.Truck:
                                Vehicle newTruck;
                                Console.WriteLine("The truck have dangerous materials?");
                                //Add bool 
                                //max wheight
                              /*  VehicleBuilder truck = new TruckBuilder();
                                newTruck = createConstructor.Construct(truck, modelName, licenseNumber, currentEnergy,
                                    6f,
                                    manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
                                m_Data.AddNewVehicle(newTruck, owner);*/
                                break;
                        }


                        break;
                    case eMenuItem.ShowVehiclesByLicenseNumber:
                        //  ShowVehiclesByLicenseNumber();
                        break;
                    case eMenuItem.ChangeVehicleStatus:
                        //    changeVehicleStatus();
                        break;
                    case eMenuItem.FillAirPressure:
                        //     fillAirToMaximum();
                        break;
                    case eMenuItem.ReFillFuelVehicle:
                        //     ReFillFuelVehicle();
                        break;
                    case eMenuItem.ChargeVehicleBattery:
                        //     chargeVehicleBattery();
                        break;
                    case eMenuItem.DisplayVehicleFullDetailsByLicenseNumber:
                        Console.WriteLine("Enter LicenseNumber");
                        licenseNumber = Console.ReadLine();
                        ShowVehicleByLicenseNumber(licenseNumber);
                        Console.ReadLine();
                        break;
                    case eMenuItem.Exit:
                        //       exitGarageProgram();
                        break;
                }
            }
        }

        private void ShowVehicleByLicenseNumber(string i_LicenseNumber)
        {
            Console.WriteLine(m_Data.GetDetails(i_LicenseNumber));
        }

        private void RefillEnergySource(string i_LicenseNumber,float i_AmountToFill,object i_FuelTypeOptional=null)
        {
            m_Data.FillEnergyResource(i_LicenseNumber, i_AmountToFill, i_FuelTypeOptional);
        }

        private void CreateNewVehicle(Constructor i_Constructor,VehicleBuilder i_Builder,VehicleOwner i_Owner, string i_ModelName, string i_LicenseNumber, float i_EnergyLeftPercentage,
            float i_CurrentEnergyStorageStatus, string i_WheelManufacturerName, float i_WheelCurrentAirPressure,object i_FirstProperty,object i_SecondProperty)
        {
            Vehicle innerVehicle = i_Constructor.Construct(i_Builder, i_ModelName, i_LicenseNumber, i_EnergyLeftPercentage,
                                                        i_CurrentEnergyStorageStatus, i_WheelManufacturerName, i_WheelCurrentAirPressure,
                                                        i_FirstProperty, i_SecondProperty);
            m_Data.AddNewVehicle(innerVehicle, i_Owner);
        }
        private void VehicleDefaultDetails(out string o_ModelName, out string o_LicenseNumber,out float o_EnergyLeftPercentage,
                                out float o_CurrentEnergyStorageStatus, out string o_WheelManufacturerName, out float o_WheelCurrentAirPressure)
        {
            Console.WriteLine("Enter model name:");
            o_ModelName = Console.ReadLine();
            Console.WriteLine("Enter license number:");
            o_LicenseNumber = Console.ReadLine();
            Console.WriteLine("Enter your current Energy Left Percentage:");
            o_EnergyLeftPercentage = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter your current energy:");
            o_CurrentEnergyStorageStatus = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter wheel Manufacturer name:");
            o_WheelManufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            o_WheelCurrentAirPressure = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter owner name:");
            string ownerName = Console.ReadLine();
        }
        private eColor ColorSelection()
        {
            Console.WriteLine(@"Color Menu :  
1. Blue
2. Black
3. Red
4. White");
            string colorSelection = Console.ReadLine();
            eColor manuColorSelection = eColor.None;
            manuColorSelection =
                (eColor)
                    Enum.Parse(typeof(eColor), ValidSelection(colorSelection, 4));
            return manuColorSelection;
        }

        private eNumberOfDoors DoorsSelection()
        {
            Console.WriteLine(@"Color Menu :  
1. Two
2. Three
3. Four
4. Five");
            string doorsSelection = Console.ReadLine();
            eNumberOfDoors manuDoorsSelection = eNumberOfDoors.None;
            manuDoorsSelection =
                (eNumberOfDoors)
                    Enum.Parse(typeof(eNumberOfDoors), ValidSelection(doorsSelection, 4));
            return manuDoorsSelection;
        }


        private void ManuMotorCycle(out int o_EngineCm,out eLicenseType o_LicenseType)
        {
            Console.WriteLine(string.Format(
                @"Garage Menu :  
1. A
2. A1
3. A4
4. C"));
            string licenseSelection = Console.ReadLine();
            eLicenseType manuLicenseSelection = eLicenseType.None;
            o_LicenseType =
                (eLicenseType)
                    Enum.Parse(typeof (eLicenseType), ValidSelection(licenseSelection, 4));
            Console.WriteLine("Enter engine by cm:");
            o_EngineCm = Convert.ToInt32(Console.ReadLine());
        }

        private string ValidSelection(string i_StrMenSelection, int i_NumberOfManu)
        {
            string correctSelection = null;
            while (correctSelection == null)
            {
                for (int i = 1; i <= i_NumberOfManu; i++)
                {
                    if (i_StrMenSelection == i.ToString())
                    {
                        correctSelection = i_StrMenSelection;
                        break;
                    }
                }
                if (correctSelection == null)
                {
                    Console.WriteLine("Please select valid number");
                    i_StrMenSelection = Console.ReadLine();
                }
            }
            return correctSelection;
        }
    }
}

