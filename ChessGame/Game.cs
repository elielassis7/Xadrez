using System;
using System.Collections.Generic;
using ChessBoard;

namespace ChessGame
{
    class Game
    {
        public Board Board { get; private set; }
        public int Move { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public Game()
        {
            Board = new Board(8, 8);
            Move = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void RunMotion(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.AddQtyMovements();
            Piece pieceCaptured = Board.RemovePiece(destination);
            Board.PutPiece(p, destination);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }
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


        public HashSet<Piece> PiecesCaptured(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece item in Captured)
            {
                if (item.Color == color)
                {
                    aux.Add(item);
                }
            }
            return aux;
                        
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {

            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece item in Pieces)
            {
                if (item.Color == color)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PiecesCaptured(color));
            return aux;
        }
        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new PositionChess(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPieces()
        {
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));

            
        }
    }
}
