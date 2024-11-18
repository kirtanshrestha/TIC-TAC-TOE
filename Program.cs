using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter player 1 name: ");
            string p1 = Console.ReadLine();

            Console.WriteLine("Enter player 2 name: ");
            string p2 = Console.ReadLine();

            int win;
            string winner;
            int p1c = 0;
            int p2c = 0;


            string cont;

            while (true)
            {
                win = startGame(p1, p2);
                if (win == -1)
                {
                    Console.WriteLine("match drawn!");
                    p1c++;
                    p2c++;
                }
                else
                {
          
                    winner = (win == 0) ? p2 : p1;
                    (win == 0 ? ref p2c : ref p1c)++;

                    Console.WriteLine($"{winner} won! ");
                }

                System.Console.WriteLine("Game Over!");
                System.Console.WriteLine("------------------------------------------");
                System.Console.WriteLine($"STATS: {p1} : {p1c} | {p2} : {p2c}");
                System.Console.Write("Enter 1 to stop. Anything else to continue: ");
                cont = Console.ReadLine();
             
                if (cont.Equals("1"))
                    break;
            }
        }

        static int startGame(string p1, string p2)
        {

            int[,] board = new int[3, 3]
            {
                { -1, -1, -1 },
                { -1, -1, -1 },
                { -1, -1, -1 }
            };
            String[] players = new string[2];
            players[1] = p1 + " (X)";
            players[0] = p2 + " (O)";



            int win = -1;

            int count = 0;
            for (int i = 1; (win == -1 && count < 9); i++, count++)
            {
                drawBoard(board);

                if (i == 2)
                    i -= 2;
                Console.WriteLine($"Enter your choice  {players[i]}: ");

                int c = Convert.ToInt16(Console.ReadLine());
                inputs(board, i, c);
                if (count > 3)
                    win = winCheck(board);
            }

            if (count == 9)
                return -1;

            return win;//for draw
        }

        private static void inputs(int[,] board, int p, int c)
        {
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (k + i + j + 1 == c && board[i, j] == -1)
                    {
                        if (p == 1)
                        {
                            board[i, j] = 1;
                            return;
                        }

                        if (p == 0)
                        {
                            board[i, j] = 0;
                            return;
                        }
                    }
                }
                k += 2;
            }

            Console.WriteLine($"You played illegal move.");
            Environment.Exit(1);
        }

        private static int winCheck(int[,] board)
        {
            for (int i = 0; i < 2; i++)
            {
                if (board[1, 1] == i)
                {
                    if (board[0, 1] == i && board[2, 1] == i)
                        return i;

                    if (board[0, 0] == i && board[2, 2] == i)
                        return i;

                    if (board[0, 2] == i && board[2, 0] == i)
                        return i;

                    if (board[1, 0] == i && board[1, 2] == i)
                        return i;

                }

                if (board[0, 0] == i && board[1, 0] == i && board[2, 0] == i)
                    return i;

                if (board[0, 2] == i && board[1, 2] == i && board[2, 2] == i)
                    return i;


                if (board[0, 0] == i && board[0, 1] == i && board[0, 2] == i)
                    return i;

                if (board[2, 0] == i && board[2, 1] == i && board[2, 2] == i)
                    return i;
            }
            return -1;
        }




        static void drawBoard(int[,] brd)
        {
            int counter = 1;
            string[,] board = new string[3, 3]
            {
                { " ", " ", " " },
                { " ", " ", " " },
                { " ", " ", " " }
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (brd[i, j] == 1)
                        board[i, j] = "X";
                    else if (brd[i, j] == 0)
                        board[i, j] = "0";
                    else
                        board[i, j] = Convert.ToString(counter);
                    counter++;
                }
            }

            Console.WriteLine("  {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine(" ---+---+---");
            Console.WriteLine("  {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
        }


    }

}
