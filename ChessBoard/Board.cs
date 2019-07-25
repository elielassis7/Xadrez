namespace ChessBoard
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int Lines, int Columns)
        {
            return Pieces[Lines, Columns];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool ThereIsAPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ThereIsAPiece(pos))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool RightPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!RightPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
