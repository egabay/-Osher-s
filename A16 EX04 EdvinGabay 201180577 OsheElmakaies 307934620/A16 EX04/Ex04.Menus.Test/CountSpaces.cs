using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IActionListeners
    {
        public void Operate()
        {
            Console.WriteLine("Enter Sentence:");
            string sentence = Console.ReadLine();
            int countSpaces = sentence.Split().Length;
            Console.Write("The number of spaces is: {0}", countSpaces - 1);
        }
    }
}
