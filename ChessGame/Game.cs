using System;
using ChessBoard;

namespace ChessGame
{
    class Game
    {
        public Board Board { get; private set; }
        private int Move;
        private Color CurrentPlayer;
        public bool EndGame { get; private set; }

        public Game()
        {
            Board = new Board(8, 8);
            Move = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            PutPieces();
        }

        public void RunMotion(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.AddQtyMovements();
            Piece pieceCaptured = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new PositionChess('a',1).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new PositionChess('h', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());

        }
    }
}
