﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05
{

    class Program
    {
        [STAThread]
        static void Main()
        {
            //stam
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CheckersGui());
        }
    }
}