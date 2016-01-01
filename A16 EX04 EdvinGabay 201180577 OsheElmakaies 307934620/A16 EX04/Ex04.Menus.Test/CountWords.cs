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
            int count = 0;
            Console.WriteLine("Enter Sentence:");
            string sentence = Console.ReadLine();
            if (sentence != null)
            {
                if (sentence[0] != ' ')
                {
                    count++; 
                }
                for (int i = 0; i < sentence.Length-1; i++)
                {
                    if (sentence[i] == ' ' && sentence[i+1] != ' ')
                    {
                        count++; 
                    }
                }  
            }
            Console.WriteLine("The number of words is:{0}", count);
        }
    }
}
