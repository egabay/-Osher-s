using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : Menu
    {
        private readonly List<IActionListeners> r_ListenersInterfaceList;

        public ActionItem(string i_MenuTitle, SubMenu i_Parent) : base(i_MenuTitle, i_Parent)
        {
            r_ListenersInterfaceList = new List<IActionListeners>();
        }

        private void OnSelection()
        {
            foreach (IActionListeners item in r_ListenersInterfaceList)
            {
                item.Operate();
            }
        }

        public void AddActionListeners(IActionListeners i_ActionListeners)
        {
            if (i_ActionListeners != null)
            {
                r_ListenersInterfaceList.Add(i_ActionListeners);
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
