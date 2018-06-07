using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static string[] position = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Board()
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", position[1], position[2], position[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", position[4], position[5], position[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", position[7], position[8], position[9]);
        }
        static void Main(string[] args)
        {
            string player1 = "", player2 = "";
            int choice = 0, turn = 1, score1 = 0, score2 = 0;
            bool winFlag = false, playing = true, correctInput = false;

            Console.WriteLine("Hello! This is Tic Tac Toe. If you don't know the rules then stop being an idiot.");
            Console.WriteLine("What is the name of player 1?");
            player1 = Console.ReadLine();
            Console.WriteLine("Very good. What is the name of player 2?");
            player2 = Console.ReadLine();
            Console.WriteLine("Okay good. {0} is O and {1} is X.", player1, player2);
            Console.WriteLine("{0} goes first.", player1);
            Console.ReadLine();
            Console.Clear();

            while (playing == true)
            {
                while (winFlag == false) // Game loop ------------------------------------------------------
                {
                    Board();
                    Console.WriteLine("");

                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    if (turn == 1)
                    {
                        Console.WriteLine("{0}'s (O) turn", player1);
                    }
                    if (turn == 2)
                    {
                        Console.WriteLine("{0}'s (X) turn", player2);
                    }

                    while (correctInput == false)
                    {
                        Console.WriteLine("Which position would you like to take?");
                        choice = int.Parse(Console.ReadLine());
                        if (choice > 0 && choice < 10)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    correctInput = false; // Reset -------

                    if (turn == 1)
                    {
                        if (position[choice] == "X") // Checks to see if spot is taken already --------------------
                        {
                            Console.WriteLine("You can't steal positions asshole! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            position[choice] = "O";
                        }
                    }
                    if (turn == 2)
                    {
                        if (position[choice] == "O") // Checks to see if spot is taken already -------------------
                        {
                            Console.WriteLine("You can't steal positions asshole! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            position[choice] = "X";
                        }
                    }

                    winFlag = CheckWin();

                    if (winFlag == false)
                    {
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                        else if (turn == 2)
                        {
                            turn = 1;
                        }
                        Console.Clear();
                    }
                }

                Console.Clear();

                Board();

                for (int i = 1; i < 10; i++) // Resets board ------------------------
                {
                    position[i] = i.ToString();
                }

                if (winFlag == false) // No one won ---------------------------
                {
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");
                    Console.WriteLine("");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset -------------

                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }

                if (winFlag == true) // Someone won -----------------------------
                {
                    if (turn == 1)
                    {
                        score1++;
                        Console.WriteLine("{0} wins!", player1);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again");
                        Console.WriteLine("2. Leave");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Enter your option: ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset --------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for playing!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }

                    if (turn == 2)
                    {
                        score2++;
                        Console.WriteLine("{0} wins!", player2);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again");
                        Console.WriteLine("2. Leave");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Enter your option: ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset -----------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for playing!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }
                }
            }
        }

        static bool CheckWin() // Win checker method ================================================
        {
            if (position[1] == "O" && position[2] == "O" && position[3] == "O") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (position[4] == "O" && position[5] == "O" && position[6] == "O")
            {
                return true;
            }
            else if (position[7] == "O" && position[8] == "O" && position[9] == "O")
            {
                return true;
            }

            else if (position[1] == "O" && position[5] == "O" && position[9] == "O") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (position[7] == "O" && position[5] == "O" && position[3] == "O")
            {
                return true;
            }

            else if (position[1] == "O" && position[4] == "O" && position[7] == "O")// Coloumns ------------------------------------------
            {
                return true;
            }
            else if (position[2] == "O" && position[5] == "O" && position[8] == "O")
            {
                return true;
            }
            else if (position[3] == "O" && position[6] == "O" && position[9] == "O")
            {
                return true;
            }

            if (position[1] == "X" && position[2] == "X" && position[3] == "X") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (position[4] == "X" && position[5] == "X" && position[6] == "X")
            {
                return true;
            }
            else if (position[7] == "X" && position[8] == "X" && position[9] == "X")
            {
                return true;
            }

            else if (position[1] == "X" && position[5] == "X" && position[9] == "X") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (position[7] == "X" && position[5] == "X" && position[3] == "X")
            {
                return true;
            }

            else if (position[1] == "X" && position[4] == "X" && position[7] == "X") // Coloumns ------------------------------------------
            {
                return true;
            }
            else if (position[2] == "X" && position[5] == "X" && position[8] == "X")
            {
                return true;
            }
            else if (position[3] == "X" && position[6] == "X" && position[9] == "X")
            {
                return true;
            }
            else // No winner ----------------------------------------------
            {
                return false;
            }
        }
    }
}
