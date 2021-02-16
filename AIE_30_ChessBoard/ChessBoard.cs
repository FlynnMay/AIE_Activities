using AIE_31_ChessBoard;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ChessGame
{
    public class ChessBoard
    {
        public Vector2 pos = new Vector2(24, 24);
        public float tileSize = 42;

        // the board can be represented as an 8x8 array
        // of chess pieces. null means the spot on the board is empty.
        ChessPiece[,] board = new ChessPiece[8, 8];

        ChessPiece selectedPiece = null;
        GameManager gm = new GameManager();


        public ChessBoard()
        {
            // P C R B Q K
            // pawn, castle, rook, bishop, queen, king 

            //    row, col
            board[0, 0] = new ChessPieceRook(this, EChessSide.WHITE, 0, 0);
            board[0, 1] = new ChessPieceKnight(this, EChessSide.WHITE, 0, 1);
            board[0, 2] = new ChessPieceBishop(this, EChessSide.WHITE, 0, 2);
            board[0, 3] = new ChessPieceQueen(this, EChessSide.WHITE, 0, 3);
            board[0, 4] = new ChessPieceKing(this, EChessSide.WHITE, 0, 4);
            board[0, 5] = new ChessPieceBishop(this, EChessSide.WHITE, 0, 5);
            board[0, 6] = new ChessPieceKnight(this, EChessSide.WHITE, 0, 6);
            board[0, 7] = new ChessPieceRook(this, EChessSide.WHITE, 0, 7);
            board[1, 0] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 0);
            board[1, 1] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 1);
            board[1, 2] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 2);
            board[1, 3] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 3);
            board[1, 4] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 4);
            board[1, 5] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 5);
            board[1, 6] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 6);
            board[1, 7] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 7);

            board[6, 0] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 0);
            board[6, 1] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 1);
            board[6, 2] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 2);
            board[6, 3] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 3);
            board[6, 4] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 4);
            board[6, 5] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 5);
            board[6, 6] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 6);
            board[6, 7] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 7);
            board[7, 0] = new ChessPieceRook(this, EChessSide.BLACK, 7, 0);
            board[7, 1] = new ChessPieceKnight(this, EChessSide.BLACK, 7, 1);
            board[7, 2] = new ChessPieceBishop(this, EChessSide.BLACK, 7, 2);
            board[7, 3] = new ChessPieceQueen(this, EChessSide.BLACK, 7, 3);
            board[7, 4] = new ChessPieceKing(this, EChessSide.BLACK, 7, 4);
            board[7, 5] = new ChessPieceBishop(this, EChessSide.BLACK, 7, 5);
            board[7, 6] = new ChessPieceKnight(this, EChessSide.BLACK, 7, 6);
            board[7, 7] = new ChessPieceRook(this, EChessSide.BLACK, 7, 7);

        }

        public ChessPiece GetPiece(int row, int col)
        {
            if (row < 0 || col < 0 || row >= 8 || col >= 8)
                return null;

            return board[row, col];
        }

        public ChessPiece GetSelected()
        {
            return selectedPiece;
        }

        public void SelectTile(int row, int col)
        {
            var piece = GetPiece(row, col);
            selectedPiece = piece;
        }

        public void SetBoardPiece(int row, int col, ChessPiece piece)
        {
            board[row, col] = piece;
            gm.SaveGame(board);
        }
    }
}
