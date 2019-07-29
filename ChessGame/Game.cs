using System;
using ChessBoard;

namespace ChessGame
{
    class Game
    {
        public Board Board { get; private set; }
        public int Move { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void DoMove(Position origin, Position destination)
        {
            RunMotion(origin, destination);
            Move++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no part in the chosen position of origin!");
            }
            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The chosen part is not your!");
            }
            if (!Board.Piece(pos).ThereisPossibleMoviment())
            {
                throw new BoardException("There are no possible movements!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Position Invalid!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new PositionChess('a', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new PositionChess('h', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());

        }
    }
}
