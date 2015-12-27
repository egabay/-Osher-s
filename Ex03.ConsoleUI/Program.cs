using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Builders;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageProgram innerProgram = new GarageProgram();
            innerProgram.Run();
        }
    }
}
