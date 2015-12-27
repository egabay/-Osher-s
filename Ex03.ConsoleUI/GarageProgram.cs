using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Builders;

namespace Ex03.ConsoleUI
{
    class GarageProgram
    {
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

        GarageData m_Data = new GarageData();

        public void Run()
        {
            eMenuItem manuItemSelection = eMenuItem.None;
            string strMenSelection = string.Empty;
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
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
                        Constructor createConstructor = new Constructor();
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
                        switch (manuVehicleSelection)
                        {
                            case eVehicleManu.FuelMotorcycle:
                                ManuMotorCycle(out engineCm);
                                CreateFuelMotorCycle(manuLicenseSelection, createConstructor, owner, engineCm);
                                break;
                            case eVehicleManu.ElectricMotorcycle:
                                ManuMotorCycle(out engineCm);
                                CreateElectricMotorCycle(manuLicenseSelection, createConstructor, owner, engineCm);
                                break;
                            case eVehicleManu.FuelCar:
                                CreateFuelCar(manuLicenseSelection, createConstructor, m_Data, owner);
                                break;
                            case eVehicleManu.ElectricCar:
                                CreateElectricCar(manuLicenseSelection, createConstructor, m_Data, owner);
                                break;
                            case eVehicleManu.Truck:
                                Vehicle newTruck;
                                Console.WriteLine("The truck have dangerous materials?");
                                //Add bool 
                                //max wheight
                                VehicleDefaultDetails(ref manuLicenseSelection, out modelName,
                                    out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
                                VehicleBuilder truck = new TruckBuilder();
                                newTruck = createConstructor.Construct(truck, modelName, licenseNumber, currentEnergy,
                                    6f,
                                    manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
                                m_Data.AddNewVehicle(newTruck, owner);
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
                        Console.WriteLine(m_Data.GetDetails("1234"));
                        Console.ReadLine();
                        Console.WriteLine(m_Data.GetDetails("123"));
                        Console.ReadLine();
                        break;
                    case eMenuItem.Exit:
                        //       exitGarageProgram();
                        break;
                }
            }
        }

        private void CreateElectricCar(eLicenseType i_ManuLicenseSelection, Constructor i_Constructor, GarageData i_Data,
            VehicleOwner i_Owner)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newCar;
            CarSelection();
            DoorsSelection();
            VehicleDefaultDetails(ref i_ManuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder electricCar = new ElectricCarBuilder(CarSelection(), DoorsSelection());
            newCar = i_Constructor.Construct(electricCar, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
            i_Data.AddNewVehicle(newCar, i_Owner);
        }

        private void CreateFuelCar(eLicenseType i_ManuLicenseSelection, Constructor i_Constructor, GarageData i_Data,
            VehicleOwner i_Owner)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newCar;
            CarSelection();
            DoorsSelection();
            VehicleDefaultDetails(ref i_ManuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder fuelCar = new FueledCarBuilder(CarSelection(), DoorsSelection());
            newCar = i_Constructor.Construct(fuelCar, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
            i_Data.AddNewVehicle(newCar, i_Owner);
        }

        private eColor CarSelection()
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
                    Enum.Parse(typeof (eColor), ValidSelection(colorSelection, 4));
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
                    Enum.Parse(typeof (eNumberOfDoors), ValidSelection(doorsSelection, 4));
            return manuDoorsSelection;
        }

        private void CreateElectricMotorCycle(eLicenseType i_ManuLicenseSelection, Constructor i_Constructor,
            VehicleOwner i_Owner, int i_EngineCm)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newMotorCycle;
            VehicleDefaultDetails(ref i_ManuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder electrifMotorCycle = new ElectricMotorCycleBuilder(i_ManuLicenseSelection,
                Convert.ToInt32(i_EngineCm));
            newMotorCycle = i_Constructor.Construct(electrifMotorCycle, modelName, licenseNumber,
                currentEnergy, 6f,
                manufacturerName, currentAirPressure, i_ManuLicenseSelection, i_EngineCm);
            m_Data.AddNewVehicle(newMotorCycle, i_Owner);
        }

        private void CreateFuelMotorCycle(eLicenseType i_ManuLicenseSelection, Constructor i_Constructor,
            VehicleOwner i_Owner, int i_EngineCm)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newMotorCycle;
            VehicleDefaultDetails(ref i_ManuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder fuelMotorCycle = new FueledMotorCycleBuilder(i_ManuLicenseSelection,
                Convert.ToInt32(i_EngineCm));
            newMotorCycle = i_Constructor.Construct(fuelMotorCycle, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, i_ManuLicenseSelection, i_EngineCm);
            m_Data.AddNewVehicle(newMotorCycle, i_Owner);
        }

        private void VehicleDefaultDetails(ref eLicenseType i_ManuLicenseSelection, out string i_ModelName,
            out string i_LicenseNumber, out float i_CurrentEnergy, out string i_ManufacturerName,
            out float i_CurrentAirPressure)
        {
            Console.WriteLine("Enter owner name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter model name:");
            i_ModelName = Console.ReadLine();
            Console.WriteLine("Enter license number:");
            i_LicenseNumber = Console.ReadLine();
            Console.WriteLine("Enter your current energy:");
            i_CurrentEnergy = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter wheel Manufacturer name:");
            i_ManufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            i_CurrentAirPressure = Convert.ToSingle(Console.ReadLine());
        }

        private eLicenseType ManuMotorCycle(out int i_EngineCm)
        {
            Console.WriteLine(string.Format(
                @"Garage Menu :  
1. A
2. A1
3. A4
4. C"));
            string licenseSelection = Console.ReadLine();
            eLicenseType manuLicenseSelection = eLicenseType.None;
            manuLicenseSelection =
                (eLicenseType)
                    Enum.Parse(typeof (eLicenseType), ValidSelection(licenseSelection, 4));
            Console.WriteLine("Enter engine by cm:");
            i_EngineCm = Convert.ToInt32(Console.ReadLine());
            return manuLicenseSelection;
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

