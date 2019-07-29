using System;
using System.Collections.Generic;
using ChessBoard;
using ChessGame;

namespace Chess
{
    class Screen
    {

        public static void PrintGame(Game Game)
        {
            PrintBoard(Game.Board);
            Console.WriteLine();
            PrintPieceCaptured(Game);
            Console.WriteLine();
            Console.WriteLine("Move: " + Game.Move);
            Console.WriteLine("Waiting for move: " + Game.CurrentPlayer);
        }

        public static void PrintPieceCaptured(Game Game)
        {
            Console.WriteLine("Pieces Captured: ");
            Console.Write("White: ");
            PrintSet(Game.PiecesCaptured(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(Game.PiecesCaptured(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece item in set)
            {
                Console.Write(item + "");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(Board board, bool[,] positionPossible)
        {
            ConsoleColor BackGroundN = Console.BackgroundColor;
            ConsoleColor BackGroundD = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (positionPossible[i, j])
                    {
                        Console.BackgroundColor = BackGroundD;
                    }
                    else
                    {
                        Console.BackgroundColor = BackGroundN;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = BackGroundN;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = BackGroundN;
        }

        public static PositionChess ReadPositionChess()
        {
            string read = Console.ReadLine();
            char col = read[0];
            int lin = int.Parse(read.Substring(1,1));
            return new PositionChess(col, lin);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
