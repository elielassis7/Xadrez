﻿using System;
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
    }
}
