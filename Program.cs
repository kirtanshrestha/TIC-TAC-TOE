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
            string u1 = Console.ReadLine();

            Console.WriteLine("Enter player 2 name: ");
            string u2 = Console.ReadLine();

            int win;
            string winner;

            while (true)
            {
                win = startGame(u1, u2);
                if(win == -1)
                    Console.WriteLine("match drawn!");
                else
                {
                    winner = (win == 0) ? u2 : u1;
                    Console.WriteLine($"Player {winner} won! ");
                }
            }
        }

        static int startGame(string u1, string u2)
        {
          
            int[,] board = new int[3, 3]
            {
                { -1, -1, -1 },
                { -1, -1, -1 },
                { -1, -1, -1 }
            };
            String[] players = new string[2];
            players[1] = u1+" (X)";
            players[0] = u2+" (O)";

           

            int win = -1;

            int count = 0;
            for (int i = 1; (win == -1 && count<8) ; i++, count++)
            {
                drawBoard(board);

                if (i == 2)
                    i -= 2;
                Console.WriteLine($"Enter your choice  {players[i]}: ");

                int c = Convert.ToInt16(Console.ReadLine());
                inputs(board, i, c);

                win = winCheck(board);


            }

            if (count == 8)
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
