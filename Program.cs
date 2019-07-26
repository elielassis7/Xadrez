﻿using System;
using ChessBoard;
using ChessGame;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game Game = new Game();

                while (!Game.EndGame)
                {
                    Console.Clear();
                    Screen.PrintBoard(Game.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadPositionChess().ToPosition();
                    Game.RunMotion(origin, destination);
                }
                 
                

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
