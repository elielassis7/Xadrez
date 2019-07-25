using System;
using ChessBoard;
using ChessGame;

namespace Chess
    {
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Rook(board, Color.White), new Position(0, 1));
            board.PutPiece(new Rook(board, Color.Black), new Position(0, 2));
            Screen.PrintBoard(board);
        }
    }
}
