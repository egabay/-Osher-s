﻿using System;
﻿using System.CodeDom;
﻿using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;
﻿using Ex02_Baord;

namespace Ex02_New
{
    // $G$ DSN-002 (-20) You should seperate UI and Logical parts! Logical classes should not be UI interactive.
    class CheckersGame
    {
        private Board m_Game;
        private PlayerInfo m_Player1;
        private PlayerInfo m_Player2; 
        private string m_BoardSize;
        private GameLogic m_Logic = new GameLogic();
        
        private void CreatingTable(string tableSize)
        {
            switch (tableSize)
            {
                // $G$ CSS-999 (-3) You should have used constants here.
                case "6x6":
                    {
                        Screen.Clear();
                        m_Game = new Board(6);
                        m_Player1.UpdatePawnsNumber(m_Game.NumberOfX);
                        break;
                    }
                case "8x8":
                    {
                        Screen.Clear();
                        m_Game = new Board(8);
                        m_Player1.UpdatePawnsNumber(m_Game.NumberOfX);
                        break;
                    }
                case "10x10":
                    {
                        Screen.Clear();
                        m_Game = new Board(10);
                        m_Player1.UpdatePawnsNumber(m_Game.NumberOfX);
                        break;
                    }
            }
        }

        public void DrawTable()
        {
            StringBuilder printOut = new StringBuilder();
            StringBuilder lineSpacer = new StringBuilder();
            printOut.Append("  ");
            for (char i = 'A'; i < m_Game.sizeOfTable + 'A'; i++)
            {
                printOut.Append(i).Append(' ');
            }

            printOut.AppendLine();

            for (int j = 0; j < m_Game.sizeOfTable * 2 + 3; j++)
            {
                lineSpacer.Append('=');
            }
            printOut.Append(lineSpacer);
            printOut.AppendLine();

            for (int i = 0; i < m_Game.sizeOfTable; i++)
            {
                char line = (char)(i + 'a');
                printOut.Append(line);
                for (int j = 0; j < m_Game.sizeOfTable; j++)
                {
                    printOut.Append('|');
                    if (m_Game[i, j] != ePlayer.Empty)
                    {
                        printOut.Append(m_Game[i, j]);
                    }
                    else
                    {
                        printOut.Append(" ");
                    }
                }
                printOut.Append('|').AppendLine();
                printOut.Append(lineSpacer);
                printOut.AppendLine();
            }
            Console.WriteLine(printOut);
        }

        private void ManuForPlayer2(string whichPlayer)
        {
            switch (whichPlayer)
            {
                case "1":
                    {
                        Console.WriteLine("Please enter player2 name:");
                        string player2Name = Console.ReadLine();
                        player2Name = CheckValidPlayerName(player2Name);
                        m_Player2 = new PlayerInfo(player2Name, ePlayer.O, ePlayer.U);
                        break;
                    }
                case "2":
                    {
                        string player2Name = "Computer";
                        m_Player2 = new PlayerInfo(player2Name, ePlayer.O, ePlayer.U);
                        break;
                    }
            }
        }

        private static string CheckManuForPlayer2(string whichPlayer)
        {
            while (whichPlayer != "1" && whichPlayer != "2")
            {
                Screen.Clear();
                Console.WriteLine("Wrong, enter again.");
                Console.WriteLine("Press to choose:");
                Console.WriteLine("1. Second Player");
                Console.WriteLine("2. Computer");
                whichPlayer = (Console.ReadLine());
            }
            return whichPlayer;
        }

        private static string CheckValidTableSize(string tableSize)
        {
            while (tableSize != "6x6" && tableSize != "8x8" && tableSize != "10x10")
            {
                Console.WriteLine("Wrong, please enter a valid size: 6x6 , 8x8 , 10x10 ");
                tableSize = Console.ReadLine();
            }
            return tableSize;
        }

        private static string CheckValidPlayerName(string player1Name)
        {
            while (string.IsNullOrEmpty(player1Name) || player1Name.Length > 20)
            {
                Screen.Clear();
                Console.WriteLine("Wrong, please enter a vaild name:");
                player1Name = Console.ReadLine();
            }
            return player1Name;
        }

        // $G$ DSN-003 (0) the code should be divided to methods
        // $G$ DSN-003 (-5) This method is too loooooooooooooooooong.
        // you need a methods like "getSettings" 
        public void Run()
        {
            if (m_Player1 == null)
            {
                Console.WriteLine("Please enter player1 name:");
                string player1Name;
                player1Name = Console.ReadLine();
                player1Name = CheckValidPlayerName(player1Name);
                m_Player1 = new PlayerInfo(player1Name, ePlayer.X, ePlayer.K);
                Console.WriteLine("Do you want to play 2 players or against the computer?");
                Console.WriteLine("Press to choose:");
                Console.WriteLine("1. Second Player");
                Console.WriteLine("2. Computer");
                string choosePlayer2 = Console.ReadLine();
                choosePlayer2 = CheckManuForPlayer2(choosePlayer2);
                ManuForPlayer2(choosePlayer2);
            }
            string tableSize;
            if (m_BoardSize != null)
            {
                CreatingTable(m_BoardSize);
            }
            else
            {
                Console.WriteLine("Please select table size : 6x6 , 8x8 , 10x10");
                tableSize = Console.ReadLine();
                tableSize = CheckValidTableSize(tableSize);
                m_BoardSize = tableSize;
                CreatingTable(tableSize);
            }
            m_Game.InitializeTable();
            DrawTable();
            string movement = null;
            PlayerInfo currentPlayer = m_Player1;
            PlayerInfo nextPlayer = m_Player2;
            int indexTurn = 1;
            string[] arrayOfEatingPossitions = new string[16];
            bool canEatAgainStatus = false;
            currentPlayer = WhoIsThePlayerNow(indexTurn, currentPlayer, ref nextPlayer);
            // $G$ DSN-999 (0) Wow!!!!!!!! really not readable... why not 'while(!SomeLogicClass.IsGameOver())' ?
            while (!m_Game.IsThereAWinner() && ( (m_Game.AvailableMoves(currentPlayer.ENormalSign, out arrayOfEatingPossitions)
                || m_Game.AvailableMoves(currentPlayer.EKinglSign, out arrayOfEatingPossitions)) || (m_Game.CheckForEatingMovesFirst(currentPlayer.ENormalSign, out arrayOfEatingPossitions)
                   && m_Game.CheckForEatingMovesFirst(currentPlayer.ENormalSign, out arrayOfEatingPossitions) || m_Game.CheckForEatingMovesFirst(currentPlayer.ENormalSign, out arrayOfEatingPossitions)
                   && m_Game.CheckForEatingMovesFirst(currentPlayer.EKinglSign, out arrayOfEatingPossitions))) )
            {
                currentPlayer = WhoIsThePlayerNow(indexTurn, currentPlayer, ref nextPlayer);
                ePlayer currentSign = currentPlayer.ENormalSign;
                int moveFromLineIndex;
                int moveFromRowIndex;
                int moveToLineIndex;
                int moveToRowIndex;
                if (currentPlayer.Name == "Computer")
                {
                    Console.WriteLine("{0}'s turn ({1}):", currentPlayer.Name, currentPlayer.ENormalSign);
                    Console.WriteLine("Press enter to see Copmuter's move:");
                    Console.ReadLine();
                    Screen.Clear();
                    m_Game.CheckForEatingMovesFirst(currentPlayer.ENormalSign, out arrayOfEatingPossitions);
                    if (arrayOfEatingPossitions[0] == null)
                    {
                        m_Game.CheckForEatingMovesFirst(currentPlayer.EKinglSign, out arrayOfEatingPossitions);
                        if (arrayOfEatingPossitions[0] != null)
                        {
                            currentSign = currentPlayer.EKinglSign;
                        }
                    }
                    if (arrayOfEatingPossitions[0] != null)
                    {
                        if (IsPlayerChoseEatingPlace(arrayOfEatingPossitions, arrayOfEatingPossitions[0]))
                        {
                            m_Game.Eat(arrayOfEatingPossitions[0], currentSign, canEatAgainStatus);
                            Screen.Clear();
                            DrawTable();
                            Console.WriteLine("{0}'s move was ({1}): {2}", currentPlayer.Name, currentSign,
                                arrayOfEatingPossitions[0]);
                            m_Game.ConvertToIndexNumbers(arrayOfEatingPossitions[0], out moveFromLineIndex,
                                out moveFromRowIndex, out moveToLineIndex, out moveToRowIndex);
                            if (!m_Game.IsAnotherEatingMoveAvailable(currentSign, moveToRowIndex, moveToLineIndex))
                            {
                                indexTurn++;
                                canEatAgainStatus = false;
                            }
                            else
                            {
                                canEatAgainStatus = true;
                            }
                        }
                    }
                    else
                    {
                        m_Game.AvailableMoves(currentSign, out arrayOfEatingPossitions);
                        m_Game.Move(arrayOfEatingPossitions[0], currentSign);
                        DrawTable();
                        Console.WriteLine("{0}'s move was ({1}): {2}", currentPlayer.Name, currentSign,
                            arrayOfEatingPossitions[0]);
                        indexTurn++;
                    }
                }
                else
                {
                    Console.WriteLine("{0}'s turn ({1}):", currentPlayer.Name, currentPlayer.ENormalSign);
                    Console.WriteLine("Enter your move:");
                    movement = Console.ReadLine();
                    while (!m_Game.IsGoodMoveData(movement))
                    {
                        Screen.Clear();
                        DrawTable();
                        Console.WriteLine("Bad data, please enter correct format");
                        movement = Console.ReadLine();
                    }
                    m_Game.ConvertToIndexNumbers(movement, out moveFromLineIndex, out moveFromRowIndex,
                    out moveToLineIndex, out moveToRowIndex);
                    if (m_Game[moveFromRowIndex, moveFromLineIndex] == currentPlayer.EKinglSign)
                    {
                        currentSign = currentPlayer.EKinglSign;
                    }
                    if (m_Game[moveFromRowIndex, moveFromLineIndex] != currentSign)
                    {
                        Screen.Clear();
                        DrawTable();
                        Console.WriteLine("Bad move! please enter again");
                    }
                    m_Game.CheckForEatingMovesFirst(currentSign, out arrayOfEatingPossitions);
                    if (arrayOfEatingPossitions[0] != null)
                    {
                        if (IsPlayerChoseEatingPlace(arrayOfEatingPossitions, movement))
                        {
                            m_Game.Eat(movement, currentSign, canEatAgainStatus);
                            Screen.Clear();
                            DrawTable();
                            Console.WriteLine("{0}'s move was ({1}): {2}", currentPlayer.Name, currentSign, movement);
                            if (!m_Game.IsAnotherEatingMoveAvailable(currentSign, moveToRowIndex, moveToLineIndex))
                            {
                                indexTurn++;
                                canEatAgainStatus = false;
                            }
                            else
                            {
                                canEatAgainStatus = true;
                            }
                        }
                        else
                        {
                            Screen.Clear();
                            DrawTable();
                            Console.WriteLine("Bad move! You must perform your eating move first!");
                        }
                    }
                    if (m_Game.IsGoodMoveData(movement) && arrayOfEatingPossitions[0] == null &&
                        m_Game[moveFromRowIndex, moveFromLineIndex] == currentSign)
                    {
                        switch (
                            m_Game.CheckWhichMoveIsIt(moveFromRowIndex, moveToRowIndex, moveFromLineIndex,
                                moveToLineIndex, currentSign, canEatAgainStatus))
                        {
                            case eMoveType.Move:
                            {
                                try
                                {
                                    m_Game.Move(movement, currentSign);
                                    Screen.Clear();
                                    DrawTable();
                                    Console.WriteLine("{0}'s move was ({1}): {2}", currentPlayer.Name, currentSign,
                                        movement);
                                    indexTurn++;
                                }
                                catch (Exception e)
                                {
                                    Screen.Clear();
                                    DrawTable();
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                            case eMoveType.Eat:
                            {
                                try
                                {
                                    m_Game.Eat(movement, currentSign, canEatAgainStatus);
                                    Screen.Clear();
                                    DrawTable();
                                    Console.WriteLine("{0}'s move was ({1}): {2}", currentPlayer.Name, currentSign,
                                        movement);
                                    if (!m_Game.IsAnotherEatingMoveAvailable(currentSign, moveFromRowIndex,
                                        moveFromLineIndex))
                                    {
                                        indexTurn++;
                                        canEatAgainStatus = false;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                            case eMoveType.None:
                            {
                                Screen.Clear();
                                DrawTable();
                                Console.WriteLine("Bad move! please enter again");
                                break;
                            }
                        }
                    }

                }
            }
            if (m_Game.IsThereAWinner())
            {
                
                if (m_Game.NumberOfO == 0 && m_Game.NumberOfU == 0)
                {
                    m_Player1.Score += (m_Game.NumberOfX + (m_Game.NumberOfK)*4);
                    Console.WriteLine("The winner is {0}, his score:{1}, and {2}'s score is:{3} ", m_Player1.Name, m_Player1.Score, m_Player2.Name, m_Player2.Score);
                    m_Player1.PlayerAmountOfWins++;
                }
                else if (m_Game.NumberOfX == 0 && m_Game.NumberOfK == 0)
                {
                    m_Player2.Score = (m_Game.NumberOfO + (m_Game.NumberOfU)*4);
                    Console.WriteLine("The winner is {0} his score:{1}, and {2}'s score is:{3} ", m_Player2.Name, m_Player2.Score, m_Player1.Name, m_Player1.Score);
                    m_Player2.PlayerAmountOfWins++;
                }
            }
            else
            {
                if (m_Game.AvailableMoves(nextPlayer.ENormalSign, out arrayOfEatingPossitions)
                    && m_Game.AvailableMoves(nextPlayer.EKinglSign, out arrayOfEatingPossitions) &&
                    m_Game.CheckForEatingMovesFirst(nextPlayer.ENormalSign, out arrayOfEatingPossitions)
                    && m_Game.CheckForEatingMovesFirst(nextPlayer.EKinglSign, out arrayOfEatingPossitions))
                {
                    Console.WriteLine("It's a draw");
                }
                else
                {
                    if (nextPlayer.ENormalSign == ePlayer.X)
                    {
                        m_Player1.Score += (m_Game.NumberOfX + (m_Game.NumberOfK) * 4) - (m_Game.NumberOfO + (m_Game.NumberOfU) * 4);
                        Console.WriteLine("The winner is {0}, his score:{1}, and {2}'s score is:{3} ", m_Player1.Name, m_Player1.Score, m_Player2.Name, m_Player2.Score);
                        m_Player1.PlayerAmountOfWins++;
                    }
                    else if (nextPlayer.ENormalSign == ePlayer.O)
                    {
                        m_Player2.Score = (m_Game.NumberOfO + (m_Game.NumberOfU)*4) - (m_Game.NumberOfX + (m_Game.NumberOfK)*4);
                        Console.WriteLine("The winner is {0}, his score:{1}, and {2}'s score is:{3} ", m_Player2.Name, m_Player2.Score, m_Player1.Name, m_Player1.Score);
                        m_Player2.PlayerAmountOfWins++;

                    }
                }
            }
        }

        private bool IsPlayerChoseEatingPlace(string[] i_arrayOfEatingPossitions, string i_movement)
        {
            // $G$ CSS-999 (-3) Locak const bool vars should start with v_.
            const bool k_IsValid = true;
            bool retVal = !k_IsValid;
            foreach (string element in i_arrayOfEatingPossitions)
            {
                if (element == i_movement)
                {
                    retVal = k_IsValid;
                }
            }
            return retVal;
        }

        private bool ResignPlayer(string i_movement, PlayerInfo i_currentPlayer, PlayerInfo i_nextPlayer)
        {
            int score = 0; 
            if (i_currentPlayer.ENormalSign == ePlayer.O)
            {
                score = (m_Game.NumberOfX + (m_Game.NumberOfK) * 4); 
            }
            else
            {
                score = (m_Game.NumberOfO + (m_Game.NumberOfU)*4); 
            }
            if (ResignFromGame(i_movement))
            {
                Console.WriteLine("{0} resigned, the winner is {1}. The score is:{2}!", i_currentPlayer.Name, i_nextPlayer.Name, score);
                return true;
            }
            return false;
        }

        private PlayerInfo WhoIsThePlayerNow(int i_indexTurn, PlayerInfo i_currentPlayer, ref PlayerInfo i_nextPlayer)
        {
            if ((i_indexTurn % 2) != 0)
            {
                i_currentPlayer = m_Player1;
                i_nextPlayer = m_Player2;
            }
            else
            {
                i_currentPlayer = m_Player2;
                i_nextPlayer = m_Player1;
            }
            return i_currentPlayer;
        }

        private static bool ResignFromGame(string i_movement)
        {
            if (i_movement == "Q")
            {
                return true;
            }
            return false;
        }
    }
}