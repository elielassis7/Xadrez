using System;
using ChessBoard;

namespace ChessGame
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
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

            //N
            pos.SetValues(Position.Line - 1, Position.Column);
            while (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //S
            pos.SetValues(Position.Line + 1, Position.Column);
            while (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            //R
            pos.SetValues(Position.Line, Position.Column + 1);
            while (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //L
            pos.SetValues(Position.Line, Position.Column - 1);
            while (Board.RightPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}