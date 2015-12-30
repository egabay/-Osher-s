using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : SubMenu
    {
        public MainMenu(string i_MenuTitle) : base(i_MenuTitle, null)
        {
            //sdsd
        }

        public override void Show()
        {
            StringBuilder message = new StringBuilder();

            Console.Clear();
            message.AppendLine(this.Title);
            message.AppendLine("0 --> Exit");
            message.Append(getMenuOptions());
            userInput(message.ToString());
        } 
    }
}
