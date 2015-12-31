using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountWords : IActionListeners
    {
        public void Operate()
        {
            string sentence = null;
            int countWords = 0;
            Console.WriteLine("Enter Sentence:");
            sentence = Console.ReadLine();
            countWords = sentence.Split().Length;
            Console.Write("The number of words is: {0}", countWords);
        }
    }
}
