using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IActionListeners
    {
        public void Operate()
        {
            Console.Write("Today's Date is : " + DateTime.Today.Date.ToShortDateString());
        }
    }
}
