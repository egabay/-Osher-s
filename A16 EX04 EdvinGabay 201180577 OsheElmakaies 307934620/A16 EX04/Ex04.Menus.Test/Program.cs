using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Test;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceTests interfaceTests = new InterfaceTests(); 
            DelegateTests delegateTests = new DelegateTests();
            interfaceTests.CreateMenuAndShow();
            delegateTests.CreateMenuAndShow();
        }
    }
}
