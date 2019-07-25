using System;
using ChessBoard;

namespace ChessGame
{
    class PositionChess
    {
        public char PColumn { get; set; }
        public int PLine { get; set; }

        public PositionChess(char pColumn, int pLine)
        {
            PColumn = pColumn;
            PLine = pLine;
        }

        public Position ToPosition()
        {
            return new Position(8 - PLine, PColumn - 'a');
        }

        public override string ToString()
        {
            return "" + PColumn + PLine;
        }
    }
}
