using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Builders;

namespace Ex03.ConsoleUI
{
    class Program
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

        public static void Main()
        {
            eMenuItem manuItemSelection = eMenuItem.None;
            string strMenSelection = string.Empty;
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            VehicleOwner owner = new VehicleOwner();
            GarageData data = new GarageData();
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
                        Constructor add = new Constructor();
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
                                CreateFuelMotorCycle(manuLicenseSelection, add, data, owner, engineCm);
                                break;
                            case eVehicleManu.ElectricMotorcycle:
                                ManuMotorCycle(out engineCm);
                                CreateElectricMotorCycle(manuLicenseSelection, add, data, owner, engineCm);
                                break;
                            case eVehicleManu.FuelCar:
                                CreateFuelCar(manuLicenseSelection, add, data, owner);
                                break;
                            case eVehicleManu.ElectricCar:
                                CreateElectricCar(manuLicenseSelection, add, data, owner);
                                break;
                            case eVehicleManu.Truck:
                                Vehicle newTruck;
                                Console.WriteLine("The truck have dangerous materials?");
                                //Add bool 
                                //max wheight
                                VehicleDefaultDetails(ref manuLicenseSelection, out modelName,
                                    out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
                                VehicleBuilder truck = new TruckBuilder();
                                newTruck = add.Construct(truck, modelName, licenseNumber, currentEnergy,
                                    6f,
                                    manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
                                data.AddNewVehicle(newTruck, owner);
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
                        Console.WriteLine(data.GetDetails("1234"));
                        Console.ReadLine();
                        Console.WriteLine(data.GetDetails("123"));
                        Console.ReadLine();
                        break;
                    case eMenuItem.Exit:
                        //       exitGarageProgram();
                        break;
                }
            }
        }

        private static void CreateElectricCar(eLicenseType manuLicenseSelection, Constructor add, GarageData data,
            VehicleOwner owner)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newCar;
            CarSelection();
            DoorsSelection();
            VehicleDefaultDetails(ref manuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder electricCar = new ElectricCarBuilder(CarSelection(), DoorsSelection());
            newCar = add.Construct(electricCar, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
            data.AddNewVehicle(newCar, owner);
        }

        private static void CreateFuelCar(eLicenseType manuLicenseSelection, Constructor add, GarageData data,
            VehicleOwner owner)
        {
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string manufacturerName;
            float currentAirPressure;
            Vehicle newCar;
            CarSelection();
            DoorsSelection();
            VehicleDefaultDetails(ref manuLicenseSelection, out modelName,
                out licenseNumber, out currentEnergy, out manufacturerName, out currentAirPressure);
            VehicleBuilder fuelCar = new FueledCarBuilder(CarSelection(), DoorsSelection());
            newCar = add.Construct(fuelCar, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, CarSelection(), DoorsSelection());
            data.AddNewVehicle(newCar, owner);
        }

        private static eColor CarSelection()
        {
            Console.WriteLine(string.Format(
                @"Color Menu :  
1. Blue
2. Black
3. Red
4. White"));
            string colorSelection = Console.ReadLine();
            eColor manuColorSelection = eColor.None;
            manuColorSelection =
                (eColor)
                    Enum.Parse(typeof (eColor), ValidSelection(colorSelection, 4));
            return manuColorSelection;
        }

        private static eNumberOfDoors DoorsSelection()
        {
            Console.WriteLine(string.Format(
                @"Color Menu :  
1. Two
2. Three
3. Four
4. Five"));
            string doorsSelection = Console.ReadLine();
            eNumberOfDoors manuDoorsSelection = eNumberOfDoors.None;
            manuDoorsSelection =
                (eNumberOfDoors)
                    Enum.Parse(typeof (eNumberOfDoors), ValidSelection(doorsSelection, 4));
            return manuDoorsSelection;
        }

        private static void CreateElectricMotorCycle(eLicenseType i_ManuLicenseSelection, Constructor i_Add,
            GarageData i_Data,
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
            newMotorCycle = i_Add.Construct(electrifMotorCycle, modelName, licenseNumber,
                currentEnergy, 6f,
                manufacturerName, currentAirPressure, i_ManuLicenseSelection, i_EngineCm);
            i_Data.AddNewVehicle(newMotorCycle, i_Owner);
        }

        private static void CreateFuelMotorCycle(eLicenseType i_ManuLicenseSelection, Constructor i_Add,
            GarageData i_Data,
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
            newMotorCycle = i_Add.Construct(fuelMotorCycle, modelName, licenseNumber, currentEnergy,
                6f,
                manufacturerName, currentAirPressure, i_ManuLicenseSelection, i_EngineCm);
            i_Data.AddNewVehicle(newMotorCycle, i_Owner);
        }

        private static void VehicleDefaultDetails(ref eLicenseType manuLicenseSelection, out string modelName,
            out string licenseNumber, out float currentEnergy, out string manufacturerName, out float currentAirPressure)
        {
            Console.WriteLine("Enter owner name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter model name:");
            modelName = Console.ReadLine();
            Console.WriteLine("Enter license number:");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter your current energy:");
            currentEnergy = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter manufacturer name:");
            manufacturerName = Console.ReadLine();
            Console.WriteLine("Enter current air pressure:");
            currentAirPressure = Convert.ToSingle(Console.ReadLine());
        }

        private static eLicenseType ManuMotorCycle(out int engineCm)
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
            engineCm = Convert.ToInt32(Console.ReadLine());
            return manuLicenseSelection;
        }

        private static string ValidSelection(string i_StrMenSelection, int i_NumberOfManu)
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
