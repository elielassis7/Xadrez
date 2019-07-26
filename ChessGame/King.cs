using System;
using ChessBoard;

namespace ChessGame
{
    class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoviment()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);
            // N
            pos.SetValues(Position.Line - 1, Position.Column);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NE
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // R
            pos.SetValues(Position.Line , Position.Column + 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SE
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // S
            pos.SetValues(Position.Line + 1, Position.Column);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SW
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // L
            pos.SetValues(Position.Line , Position.Column - 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NW
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
