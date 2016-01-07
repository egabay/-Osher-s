﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex02_New
{

    class Program
    {
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CheckersGui());
        
        }
    }
}