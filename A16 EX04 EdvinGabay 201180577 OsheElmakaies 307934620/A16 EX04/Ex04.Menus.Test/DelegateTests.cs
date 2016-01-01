using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegateTests
    {
        public void CreateMenuAndShow()
        {
            MainMenu mainMenuApp = new MainMenu("Delegate Menu test");
            SubMenu firstSubMenuApp = new SubMenu("Show Data/Time", mainMenuApp);
            SubMenu secondSubMenuApp = new SubMenu("Version and Actions", mainMenuApp);
            SubMenu actionsSubMenu = new SubMenu("Actions", mainMenuApp);

            ActionItem dateAction = new ActionItem("Show Date", firstSubMenuApp);
            ActionItem timeAction = new ActionItem("Show Time", firstSubMenuApp);
            ActionItem CountSpaces = new ActionItem("Count number of spaces in the sentence", actionsSubMenu);
            ActionItem CountWords = new ActionItem("Count number of words in the sentence", actionsSubMenu);
            ActionItem versionAction = new ActionItem("Show Version", mainMenuApp);

            ShowDate date = new ShowDate();
            ShowTime time = new ShowTime();
            CountSpaces spaces = new CountSpaces();
            CountWords words = new CountWords();
            ShowVersion version = new ShowVersion();

            dateAction.Selection += date.Operate;
            timeAction.Selection += time.Operate;
            CountSpaces.Selection += spaces.Operate;
            CountWords.Selection += words.Operate;
            versionAction.Selection += version.Operate;

            firstSubMenuApp.AddItem(dateAction);
            firstSubMenuApp.AddItem(timeAction);
            secondSubMenuApp.AddItem(actionsSubMenu);
            secondSubMenuApp.AddItem(versionAction);
            actionsSubMenu.AddItem(CountSpaces);
            actionsSubMenu.AddItem(CountWords);
           
            mainMenuApp.AddItem(firstSubMenuApp);
            mainMenuApp.AddItem(secondSubMenuApp);

            mainMenuApp.Show();
        }
    }
}
