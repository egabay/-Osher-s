﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates_mainMenu;
using Ex04.Menus.Delegates_subMenu;

namespace Ex04.Menus.Delegates_Menu
{
    public abstract class Menu
    {
        protected readonly string r_Title;
        protected readonly SubMenu r_Parent;

        public Menu(string i_Title, SubMenu i_Parent)
        {
            r_Title = i_Title;
            r_Parent = i_Parent; 
        }

        public string Title
        {
            get { return r_Title; }
        }

        public SubMenu Parent
        {
            get { return r_Parent; }
        }

        public abstract void Show();
    }
}
