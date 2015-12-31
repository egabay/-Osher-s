using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;
using Ex04.Menus.Test;

namespace Ex04.Menus.Test__CountWords
{
    public class DelegateTest
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
            ShowVersion version = new ShowVersion();
            CountSpaces spaces = new CountSpaces();
            CountWords words = new CountWords();

            CountWords.Selection += words.Operate;
            CountSpaces.Selection += spaces.Operate;
            dateAction.Selection += date.Operate;
            timeAction.Selection += time.Operate;
            versionAction.Selection += version.Operate;

            firstSubMenuApp.AddItem(dateAction);
            firstSubMenuApp.AddItem(timeAction);
            secondSubMenuApp.AddItem(actionsSubMenu);
            secondSubMenuApp.AddItem(versionAction);
            actionsSubMenu.AddItem(CountSpaces);
            actionsSubMenu.AddItem(CountWords);
            //subMenuSecondApp.AddItem(CountWordsAction);

            mainMenuApp.AddItem(firstSubMenuApp);
            mainMenuApp.AddItem(secondSubMenuApp);

            mainMenuApp.Show();
        }
    }
}
