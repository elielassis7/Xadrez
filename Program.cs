using System;
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
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(Game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        Game.ValidateOriginPosition(origin);

                        bool[,] positionPossible = Game.Board.Piece(origin).PossibleMoviment();
                        Console.Clear();
                        Screen.PrintBoard(Game.Board, positionPossible);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadPositionChess().ToPosition();
                        Game.ValidateDestinationPosition(origin, destination);

                        Game.DoMove(origin, destination);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                 
                

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
