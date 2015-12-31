using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates_mainMenu;
using Ex04.Menus.Delegates_Menu;

namespace Ex04.Menus.Delegates_subMenu
{
    public class SubMenu : Menu
    {
        protected readonly List<Menu> r_MenuList;

        public SubMenu(string i_MenuTitle, MainMenu i_Parent) : base(i_MenuTitle, i_Parent)
        {
            r_MenuList = new List<Menu>();
        }

        public void AddItem(Menu i_AddedItem)
        {
            r_MenuList.Add(i_AddedItem);
        }

        protected string getMenuOptions()
        {
            StringBuilder message = new StringBuilder();
            foreach (Menu item in r_MenuList)
            {
                message.AppendLine(r_MenuList.IndexOf(item) + 1 + " --> " + item.Title);
            }

            message.Append("Put your selection: ");
            return message.ToString();
        }

        protected void userInputNumber(string i_PrintedMessage)
        {
            string userInputStr;
            int userInputInt;
            bool IsExit = true;
            bool retVal = !IsExit;
            Console.Write(i_PrintedMessage);
            do
            {
                userInputStr = Console.ReadLine();
                if (int.TryParse(userInputStr, out userInputInt))
                {
                    if (userInputInt > 0 && userInputInt <= r_MenuList.Count)
                    {
                        r_MenuList[userInputInt - 1].Show();
                        Console.Clear();
                        Console.Write(i_PrintedMessage);
                    }
                    else if (userInputInt == 0)
                    {
                        retVal = IsExit;
                    }
                    else
                    {
                        Console.WriteLine("Error! Please insert number between {0} - {1}: ", 0, r_MenuList.Count);
                    }
                }
                else
                {
                    Console.WriteLine("Error! Wrong input, insert a number: ");
                }
            } while (retVal);
        }

        public override void Show()
        {
            StringBuilder message = new StringBuilder();

            Console.Clear();
            message.AppendLine(base.Title);
            message.AppendLine("0 --> Back");
            message.Append(getMenuOptions());
            userInputNumber(message.ToString());
        }
    }
}
