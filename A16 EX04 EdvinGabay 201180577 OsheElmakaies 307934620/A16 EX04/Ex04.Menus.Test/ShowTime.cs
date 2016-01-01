﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IActionListeners
    {
        public void Operate()
        {
            Console.Write("The current time is: " + DateTime.Now.ToShortTimeString());
        }
    }
}
