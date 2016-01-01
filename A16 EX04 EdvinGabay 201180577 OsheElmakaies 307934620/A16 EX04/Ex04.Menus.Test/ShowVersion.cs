using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IActionListeners
    {
        public void Operate()
        {
            Console.Write("Version: 16.1.4.0");
        }
    }
}
