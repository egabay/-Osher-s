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

        public enum eMenuItem
        {
            None = 0,
            AddNewVehicle,
            ShowVehiclesByLicenseNumber,
            ChangeVehicleStatus,
            FillAirPressure,
            ReFillFuelVehicle,
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

        public enum eMaterials
        {
            None = 0,
            No,
            Yes
        }

        public void Run()
        {
            eMenuItem manuItemSelection = eMenuItem.None;
            string strMenSelection = string.Empty;
            string modelName;
            string licenseNumber;
            float currentEnergy;
            string wheelManufacturName;
            float wheelCurrentAirPressure;
            string ownerName;
            string ownerPhone;
            eLicenseType innerLicenseType;
            VehicleBuilder innerVehicleBuilder;

            while (manuItemSelection != eMenuItem.Exit)
            {
                Console.Clear();
                Console.WriteLine(@"Garage Menu:   
1. Add new vehicle to the garage
2. Display the list of vehicles by ID number < Licence number>
3. Change vehicle status in the garage
4. Change the air pressure to maximum
5. Refill the vehicle energy storage 
6. Display full details on vehicle
7. Exit the garage program
Press a number:");
                strMenSelection = Console.ReadLine();
                manuItemSelection = (eMenuItem) Enum.Parse(typeof (eMenuItem), validSelection(strMenSelection, 7));
                switch (manuItemSelection)
                {
                    case eMenuItem.AddNewVehicle:
                        Constructor innerConstructor = new Constructor();
                        VehicleOwner innerOwner = new VehicleOwner();
                        Console.Clear();
                        Console.WriteLine(@"Vehicle Menu:
1. Fuel motorcycle
2. Electric motorcycle
3. Fuel car
4. Electric car
5. Truck
Press a number:");
                        string vehicleSelection = Console.ReadLine();
                        int engineCm;
                        eLicenseType manuLicenseSelection = eLicenseType.None;
                        eVehicleManu manuVehicleSelection;
                        manuVehicleSelection =
                            (eVehicleManu) Enum.Parse(typeof (eVehicleManu), validSelection(vehicleSelection, 5));
                        vehicleDefaultDetails(manuVehicleSelection, out modelName, out licenseNumber,
                            out currentEnergy, out wheelManufacturName, out wheelCurrentAirPressure,
                            out ownerName, out ownerPhone);
                        innerOwner.Name = ownerName;
                        innerOwner.PhoneNumber = ownerPhone;
                        switch (manuVehicleSelection)
                        {
                            case eVehicleManu.FuelMotorcycle:
                                manuMotorCycle(out engineCm, out innerLicenseType);
                                innerVehicleBuilder = new FueledMotorCycleBuilder();
                                createNewVehicle(innerConstructor, innerVehicleBuilder, innerOwner, modelName,
                                    licenseNumber,
                                    currentEnergy, wheelManufacturName, wheelCurrentAirPressure,
                                    innerLicenseType, engineCm);
                                break;
                            case eVehicleManu.ElectricMotorcycle:
                                manuMotorCycle(out engineCm, out innerLicenseType);
                                innerVehicleBuilder = new ElectricMotorCycleBuilder();
                                createNewVehicle(innerConstructor, innerVehicleBuilder, innerOwner, modelName,
                                    licenseNumber,
                                    currentEnergy, wheelManufacturName, wheelCurrentAirPressure,
                                    innerLicenseType, engineCm);
                                break;
                            case eVehicleManu.FuelCar:
                                innerVehicleBuilder = new FueledCarBuilder();
                                createNewVehicle(innerConstructor, innerVehicleBuilder, innerOwner, modelName,
                                    licenseNumber,
                                    currentEnergy, wheelManufacturName, wheelCurrentAirPressure, colorSelection(),
                                    doorsSelection());
                                break;
                            case eVehicleManu.ElectricCar:
                                innerVehicleBuilder = new ElectricCarBuilder();
                                createNewVehicle(innerConstructor, innerVehicleBuilder, innerOwner, modelName,
                                    licenseNumber,
                                    currentEnergy, wheelManufacturName, wheelCurrentAirPressure, colorSelection(),
                                    doorsSelection());

                                break;
                            case eVehicleManu.Truck:
                                innerVehicleBuilder = new TruckBuilder();
                                createNewVehicle(innerConstructor, innerVehicleBuilder, innerOwner, modelName,
                                    licenseNumber,
                                    currentEnergy, wheelManufacturName, wheelCurrentAirPressure, materialsSelection(),
                                    maxWeight());
                                break;
                        }
                        break;
                    case eMenuItem.ShowVehiclesByLicenseNumber:
                        showVehiclesByLicenseNumber();
                        break;
                    case eMenuItem.ChangeVehicleStatus:
                        string innerLicenseNumberStatus = getLicenseNumberFromUser();
                        eVehicleStatus innerEVehicleStatus = vehicleStatus();
                        changeVehicleStatus(innerEVehicleStatus, innerLicenseNumberStatus);
                        break;
                    case eMenuItem.FillAirPressure:
                        string innerLicenseNumberPressure = getLicenseNumberFromUser();
                        fillAirToMax(innerLicenseNumberPressure);
                        break;
                    case eMenuItem.ReFillFuelVehicle:
                        refillEnergySource();
                        break;
                    case eMenuItem.DisplayVehicleFullDetailsByLicenseNumber:
                        Console.WriteLine("Enter LicenseNumber");
                        licenseNumber = Console.ReadLine();
                        showVehicleByLicenseNumber(licenseNumber);
                        Console.ReadLine();
                        break;
                    case eMenuItem.Exit:
                        break;
                }
            }
        }


        private void showVehiclesByLicenseNumber()
        {
            if (selectIfToFilterByCarStatus())
            {
                eVehicleStatus innerStatus;
                innerStatus = vehicleStatus();
                Console.WriteLine("The license numbers that are in the status: {0} are:", innerStatus);
                Console.WriteLine(m_Data.GetAllLicenseNumbers(innerStatus));
                Console.WriteLine("Press enter and go back to manu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The list of the cars in garage are:");
                Console.WriteLine(m_Data.GetAllLicenseNumbers());
                Console.WriteLine("Press enter and go back to manu");
                Console.ReadLine();
            }
        }

        private void refillEnergySource()
        {
            float finalAmountToFill;
            string innerLicenseNumber = getLicenseNumberFromUser();
            Console.WriteLine("Enter Amount to fill up");
            string inputAmountToFill = Console.ReadLine();
            inputAmountToFill = ValidNumber(inputAmountToFill);
            finalAmountToFill = Convert.ToSingle(inputAmountToFill);
            if (m_Data.IsFuelVehicle(innerLicenseNumber))
            {
                eFuelType innerFuelType;
                innerFuelType = vehicleFuelType();
                try
                {
                    m_Data.FillEnergyResource(innerLicenseNumber, finalAmountToFill, innerFuelType);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                try
                {
                    m_Data.FillEnergyResource(innerLicenseNumber, finalAmountToFill);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private float maxWeight()
        {
            Console.WriteLine("What is the maximum carrying weight?");
            string weightString = Console.ReadLine();
            weightString = ValidNumber(weightString);
            float weight = Convert.ToSingle(weightString);
            return weight;
        }

        private bool selectIfToFilterByCarStatus()
        {
            const bool v_IsFiltering = true;
            bool retVal = !v_IsFiltering;
            Console.WriteLine(@"Do you want to filter by Car Status ?
Menu :   
1. No
2. Yes
Press a number:");
            string materialsSelection = Console.ReadLine();
            eMaterials manumaterialsSelection = eMaterials.None;
            manumaterialsSelection =
                (eMaterials) Enum.Parse(typeof (eMaterials), validSelection(materialsSelection, 2));
            if (manumaterialsSelection == eMaterials.Yes)
            {
                retVal = v_IsFiltering;
            }
            return retVal;
        }

        private bool materialsSelection()
        {
            bool materialsAnswer = false;
            Console.WriteLine(@"The truck have dangerous materials?
Menu :   
1. No
2. Yes
Press a number:");
            string materialsSelection = Console.ReadLine();
            eMaterials manumaterialsSelection = eMaterials.None;
            manumaterialsSelection =
                (eMaterials) Enum.Parse(typeof (eMaterials), validSelection(materialsSelection, 2));
            if (manumaterialsSelection == eMaterials.Yes)
            {
                materialsAnswer = true;
            }
            return materialsAnswer;
        }

        private void showVehicleByLicenseNumber(string i_LicenseNumber)
        {
            Console.WriteLine(m_Data.GetDetails(i_LicenseNumber));
        }

        private void refillEnergySource(string i_LicenseNumber, float i_AmountToFill, object i_FuelTypeOptional = null)
        {
            m_Data.FillEnergyResource(i_LicenseNumber, i_AmountToFill, i_FuelTypeOptional);
        }

        private Vehicle createNewVehicle(Constructor i_Constructor, VehicleBuilder i_Builder, VehicleOwner i_Owner,
            string i_ModelName, string i_LicenseNumber,
            float i_CurrentEnergyStorageStatus, string i_WheelManufacturerName, float i_WheelCurrentAirPressure,
            object i_FirstProperty, object i_SecondProperty)
        {
            Vehicle innerVehicle = i_Constructor.Construct(i_Builder, i_ModelName, i_LicenseNumber,
                i_CurrentEnergyStorageStatus, i_WheelManufacturerName, i_WheelCurrentAirPressure,
                i_FirstProperty, i_SecondProperty);
            if (!(m_Data.AddNewVehicle(innerVehicle, i_Owner)))
            {
                Console.WriteLine("The car is already in garage, status changed to InRepair\n Enter Key To Continue");
                Console.ReadLine();
            }
            return innerVehicle;
        }

        private void vehicleDefaultDetails(eVehicleManu i_ManuVehicleSelection, out string o_ModelName,
            out string o_LicenseNumber, out float o_CurrentEnergyStorageStatus, out string o_WheelManufacturerName,
            out float o_WheelCurrentAirPressure, out string o_OwnerName, out string o_OwnerPhone)
        {
            Console.WriteLine("Enter model name:");
            o_ModelName = Console.ReadLine();
            o_ModelName = ValidString(o_ModelName);
            Console.WriteLine("Enter license number:");
            o_LicenseNumber = Console.ReadLine();
            o_LicenseNumber = ValidNumber(o_LicenseNumber);
            Console.WriteLine("Enter your current fuel capacity:");
            string fuelCapacity = Console.ReadLine();
            fuelCapacity = ValidNumber(fuelCapacity);
            o_CurrentEnergyStorageStatus = Convert.ToSingle(fuelCapacity);
            if (i_ManuVehicleSelection == eVehicleManu.FuelMotorcycle)
            {
                o_CurrentEnergyStorageStatus = ValidAirPressure(o_CurrentEnergyStorageStatus, 6f);
            }
            else if (i_ManuVehicleSelection == eVehicleManu.FuelCar)
            {
                o_CurrentEnergyStorageStatus = ValidAirPressure(o_CurrentEnergyStorageStatus, 42f);
            }
            else if (i_ManuVehicleSelection == eVehicleManu.Truck)
            {
                o_CurrentEnergyStorageStatus = ValidAirPressure(o_CurrentEnergyStorageStatus, 160f);
            }
            Console.WriteLine("Enter phone number:");
            o_OwnerPhone = Console.ReadLine();
            o_OwnerPhone = ValidNumber(o_OwnerPhone);
            Console.WriteLine("Enter wheel Manufacturer name:");
            o_WheelManufacturerName = Console.ReadLine();
            o_WheelManufacturerName = ValidString(o_WheelManufacturerName);
            Console.WriteLine("Enter current air pressure:");
            string airPressure = Console.ReadLine();
            airPressure = ValidNumber(airPressure);
            o_WheelCurrentAirPressure = Convert.ToSingle(airPressure);
            if (i_ManuVehicleSelection == eVehicleManu.ElectricMotorcycle ||
                i_ManuVehicleSelection == eVehicleManu.FuelMotorcycle)
            {
                o_WheelCurrentAirPressure = ValidAirPressure(o_WheelCurrentAirPressure, 32f);
            }
            else if (i_ManuVehicleSelection == eVehicleManu.ElectricCar || i_ManuVehicleSelection == eVehicleManu.FuelCar)
            {
                o_WheelCurrentAirPressure = ValidAirPressure(o_WheelCurrentAirPressure, 29f);
            }
            else
            {
                o_WheelCurrentAirPressure = ValidAirPressure(o_WheelCurrentAirPressure, 34f);
            }
            Console.WriteLine("Enter owner name:");
            o_OwnerName = Console.ReadLine();
            o_OwnerName = ValidString(o_OwnerName);
        }

        private eColor colorSelection()
        {
            Console.WriteLine(@"Color Menu :  
1. Blue
2. Black
3. Red
4. White
Press a number:");
            string colorSelection = Console.ReadLine();
            eColor manuColorSelection = eColor.None;
            manuColorSelection =
                (eColor)
                    Enum.Parse(typeof (eColor), validSelection(colorSelection, 4));
            return manuColorSelection;
        }

        private eNumberOfDoors doorsSelection()
        {
            Console.WriteLine(@"Color Menu :  
1. Two
2. Three
3. Four
4. Five
Press a number:");
            string doorsSelection = Console.ReadLine();
            eNumberOfDoors manuDoorsSelection = eNumberOfDoors.None;
            manuDoorsSelection =
                (eNumberOfDoors)
                    Enum.Parse(typeof (eNumberOfDoors), validSelection(doorsSelection, 4));
            return manuDoorsSelection;
        }


        private void manuMotorCycle(out int o_EngineCm, out eLicenseType o_LicenseType)
        {
            Console.WriteLine(@"License Menu :  
1. A
2. A1
3. A4
4. C");
            string licenseSelection = Console.ReadLine();
            eLicenseType manuLicenseSelection = eLicenseType.None;
            o_LicenseType =
                (eLicenseType)
                    Enum.Parse(typeof(eLicenseType), validSelection(licenseSelection, 4));
            Console.WriteLine("Enter engine by cm:");
            o_EngineCm = Convert.ToInt32(Console.ReadLine());
        }

        private void changeVehicleStatus(eVehicleStatus i_Status, string i_InnerLicenseNumber)
        {
            if (!m_Data.ChangeStatus(i_InnerLicenseNumber, i_Status))
            {
                Console.WriteLine(@"This license number is not in the garage!
Press enter and back to manu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(@"The car status changed to: {0}
Press enter and back to manu", i_Status);
                Console.ReadLine();
            }
        }

        private void fillAirToMax(string i_InnerLicenseNumber)
        {
            if (!m_Data.MaximizeWheelPressure(i_InnerLicenseNumber))
            {
                Console.WriteLine(@"This license number is not in the garage!
Press enter and back to manu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(@"The car air pressure filled to maximum!
Press enter and back to manu");
                Console.ReadLine();
            }
        }

        private string getLicenseNumberFromUser()
        {
            string innerLicenseNumber;
            Console.WriteLine("Enter license number to change the status to ");
            innerLicenseNumber = Console.ReadLine();
            innerLicenseNumber = ValidNumber(innerLicenseNumber);
            return innerLicenseNumber;
        }

        private eVehicleStatus vehicleStatus()
        {
            Console.WriteLine(@"Please enter your vehicle status:
Vehicle status Menu :  
1. InRepair
2. Paid
3. Fixed
Press a number:");
            string statusSelection = Console.ReadLine();
            eVehicleStatus manuStatusSelection;
            manuStatusSelection =
                (eVehicleStatus)
                    Enum.Parse(typeof(eVehicleStatus), validSelection(statusSelection, 3));
            return manuStatusSelection;
        }

        private eFuelType vehicleFuelType()
        {
            Console.WriteLine(@"Please enter your fuel type:
Vehicle status Menu :  
1. Octan95
2. Octan96
3. Octan98
4. Soler
Press a number:");
            string fuelSelection = Console.ReadLine();
            eFuelType manuFuelSelection;
            manuFuelSelection =
                (eFuelType)
                    Enum.Parse(typeof (eFuelType), validSelection(fuelSelection, 3));
            return manuFuelSelection;
        }

        private string validSelection(string i_StrMenSelection, int i_NumberOfManu)
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

        private string ValidString(string i_ValidStringInput)
        {
            while (string.IsNullOrEmpty(i_ValidStringInput))
            {
                Console.Clear();
                Console.WriteLine("Wrong, please enter again:");
                i_ValidStringInput = Console.ReadLine();
            }
            return i_ValidStringInput;
        }

        private string ValidNumber(string i_ValidNumberInput)
        {
            int answer;
            bool isNumeric = int.TryParse(i_ValidNumberInput, out answer);
            while (!isNumeric)
            {
                Console.Clear();
                Console.WriteLine("Wrong, please enter again:");
                i_ValidNumberInput = Console.ReadLine();
                isNumeric = int.TryParse(i_ValidNumberInput, out answer);
            }
            return i_ValidNumberInput;
        }

        private float ValidAirPressure(float i_ValidAirPressureInput, float i_MaximumPressure)
        {
            if (i_ValidAirPressureInput != null)
            {
                while (i_ValidAirPressureInput > i_MaximumPressure || i_ValidAirPressureInput < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong, please enter a vaild number between 0-{0}:", i_MaximumPressure);
                    i_ValidAirPressureInput = Convert.ToSingle(Console.ReadLine());
                }
            }
            return i_ValidAirPressureInput;
        }
    }
}


