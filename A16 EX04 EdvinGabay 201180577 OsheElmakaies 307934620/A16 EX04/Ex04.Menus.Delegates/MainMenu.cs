using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates_subMenu;

namespace Ex04.Menus.Delegates_mainMenu
{
    public class MainMenu : SubMenu
    {
        public MainMenu(string i_MenuTitle)
            : base(i_MenuTitle, null)
        {
        }

        public override void Show()
        {
            StringBuilder message = new StringBuilder();

            Console.Clear();
            message.AppendLine(Title);
            message.AppendLine("0 --> Exit");
            message.Append(getMenuOptions());
            userInputNumber(message.ToString());
        } 
    }
}
