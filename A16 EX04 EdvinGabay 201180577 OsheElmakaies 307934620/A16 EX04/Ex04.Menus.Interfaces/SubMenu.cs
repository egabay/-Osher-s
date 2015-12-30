using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : Menu
    {
        protected readonly List<Menu> r_MenuList;

        public SubMenu(string i_MenuTitle, MainMenu i_Parent) : base(i_MenuTitle, i_Parent)
        {
            this.r_MenuList = new List<Menu>();
        }

        public void AddItem(Menu i_AddItem)
        {
            r_MenuList.Add(i_AddItem);
        }

        protected string getMenuOptions()
        {
            StringBuilder message = new StringBuilder();
            foreach (Menu item in r_MenuList)
            {
                message.AppendLine(r_MenuList.IndexOf(item) + 1 + "-->" + item.Title);
            }
            message.Append("Choose your selection :");

            return message.ToString();
        }

        protected void userInput(string i_PrintedMessage)
        {
            string userInputstr;
            int userInputInt;
            bool IsExit = true;
            bool retVal = !IsExit;
            Console.WriteLine(i_PrintedMessage);
            do
            {
                userInputstr = Console.ReadLine();
                if (int.TryParse(userInputstr, out userInputInt))
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
                        Console.WriteLine("Error! Please insert number between {0}-{1}: ", 0, r_MenuList.Count);
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
            userInput(message.ToString());
        }
    }
}
