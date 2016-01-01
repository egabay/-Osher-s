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
            int count = 0;
            int i = 0;
            Console.WriteLine("Enter Sentence:");
            sentence = Console.ReadLine();
            if (sentence != null)
            {
                if (sentence[0] != ' ')
                {
                    count++; 
                }
                for (i = 0; i < sentence.Length-1; i++)
                {
                    if (sentence[i] == ' ' && sentence[i+1] != ' ')
                    {
                        count++; 
                    }
                }  
            }
            

            //while (sentence[i] == ' ' && i < sentence.Length)
            //{
            //    i++;
            //}

            //while (i < sentence.Length)
            //{
            //    if (sentence[i] == ' ')
            //    {
            //        count++;
            //    }
            //    while (sentence[i] == ' ' && i < sentence.Length)
            //    {
            //        i++;
            //    }

            //    i++;
            //}

            Console.WriteLine("The number of words is:{0}", count);
        }
    }
}
