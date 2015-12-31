using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates_actionDelegate;
using Ex04.Menus.Delegates_Menu;
using Ex04.Menus.Delegates_subMenu;

namespace Ex04.Menus.Delegates_actionItem
{
    public class ActionItem : Menu
    {
        public event ActionDelegate.SelectDelegate Selection;

        public ActionItem(string i_MenuTitle, SubMenu i_Parent) : base(i_MenuTitle, i_Parent)
        {
        }

        public void OnSelection()
        {
            if (Selection != null)
            {
                Selection.Invoke();
            }
        }

        public override void Show()
        {
            Console.Clear();
            OnSelection();
            Console.WriteLine(Environment.NewLine + "Press 'Enter' button for continue");
            Console.ReadKey();
        }
    }
}
