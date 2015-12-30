using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class Menu
    {
        protected readonly SubMenu r_Parent;
        protected readonly string r_Title;

        protected Menu(string i_Title, SubMenu i_Parent)
        {
            r_Title = i_Title;
            r_Parent = i_Parent;
        }

        public SubMenu Parent
        {
            get { return r_Parent; }
        }

        public string Title
        {
            get { return r_Title; }
        }

        public abstract void Show();
    }
}
