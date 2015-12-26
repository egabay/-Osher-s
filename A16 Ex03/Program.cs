using System;
using System.Collections.Generic;
using System.Text;

namespace A16_Ex03
{
    public class Program
    {
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

        public static void Main()
        {
            eMenuItem manuItemSelection = eMenuItem.None;
            string strMenSelection = string.Empty;

            while (manuItemSelection != eMenuItem.Exit)
            {
                Console.Clear();
                Console.WriteLine(string.Format(
                    @"Garage Menu :   

1.  Add new vehicle to the Garage
2.  Display the list of vehicles by ID number < Licence number>
3.  Change vehicle status in the Garage
4.  Change the air pressure to maximum
5.  Refill Fuel Vehicle 
6.  Charge battery Vehicle 
7.  Display full details on vehicle
8.  Exit the Garage Program"));

                strMenSelection = Console.ReadLine();
                manuItemSelection = (eMenuItem) Enum.Parse(typeof (eMenuItem), strMenSelection);
                switch (manuItemSelection)
                {
                    case eMenuItem.AddNewVehicle:
                        addNewVehicle();
                        break;
                    case eMenuItem.ShowVehiclesByLicenseNumber:
                        ShowVehiclesByLicenseNumber();
                        break;
                    case eMenuItem.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case eMenuItem.FillAirPressure:
                        fillAirToMaximum();
                        break;
                    case eMenuItem.ReFillFuelVehicle:
                        ReFillFuelVehicle();
                        break;
                    case eMenuItem.ChargeVehicleBattery:
                        chargeVehicleBattery();
                        break;
                    case eMenuItem.DisplayVehicleFullDetailsByLicenseNumber:
                        DisplayVehicleFullDetailsByLicenseNumber();
                        break;
                    case eMenuItem.Exit:
                        exitGarageProgram();
                        break;
                }
            }
        }
    }
}
