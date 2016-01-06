﻿using System;
using System.Collections.Generic;
using System.Text;


// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ RUL-005 (-20) Wrong zip folder structure
// $G$ RUL-004 (0) Wrong zip/folder name. Why "Oshe" instead of "Osher"...? 

// $G$ DSN-999 (0) Your design is not good.. Board Class shouldn't have responsibility for game logic.
// Checkers game does logic actions too, but you used it as your UI class.
// Methods are really(!!!) long. Try "speaking" with the code. Write what you want to do in methods,
// then, implement them later. For instance, you want to getSettings(). Inside you want to getPlayerName().
namespace Ex02_New
{
    // $G$ CSS-999 (-5) Your StyleCop configuration file is not correct (does not alert for blank lines correctly - missing or unneccesary)
    // $G$ CSS-999 (-3) The classes must have an access modifier.
    // $G$ SFN-999 (-5) The game crushe here with IndexOutOfRange Exception in middle of round...(when playing against a computer)
    // $G$ SFN-010 (-7) When player choose 'Q', the opponent should be the winner...
    class Program
    {
        // $G$ DSN-006 (-3) This method should be placed in a seperated class that should be used by Main method. The class Program should include only the entry point (Main) of the program.
        static void Main()
        {
            string exitOrNot;
            CheckersGame checkerGame = new CheckersGame();
            checkerGame.Run();
            Console.WriteLine("Enter X to exit or C to continue");
            exitOrNot = Console.ReadLine();
            // $G$ CSS-999 (-3) You should have used constants here.
            while (exitOrNot != "X")
            {
                // $G$ SFN-014 (-3) If you enter 'C' once, the game repeats without asking again at next game over. 
                if (exitOrNot == "C")
                {
                    checkerGame.Run();
                }
                else
                {
                    Console.WriteLine("Bad Input please re enter input");
                    exitOrNot = Console.ReadLine();
                }
            }
            Console.WriteLine("Good Bye");
        }
    }
}