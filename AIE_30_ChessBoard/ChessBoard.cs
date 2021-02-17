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
        ChessPiece[,] pieces = new ChessPiece[8, 8];

        ChessPiece selectedPiece = null;
        GameManager gm = new GameManager();


        public ChessBoard()
        {
            // P C R B Q K
            // pawn, castle, rook, bishop, queen, king 

            //    row, col
            pieces[0, 0] = new ChessPieceRook(this, EChessSide.WHITE, 0, 0);
            pieces[0, 1] = new ChessPieceKnight(this, EChessSide.WHITE, 0, 1);
            pieces[0, 2] = new ChessPieceBishop(this, EChessSide.WHITE, 0, 2);
            pieces[0, 3] = new ChessPieceQueen(this, EChessSide.WHITE, 0, 3);
            pieces[0, 4] = new ChessPieceKing(this, EChessSide.WHITE, 0, 4);
            pieces[0, 5] = new ChessPieceBishop(this, EChessSide.WHITE, 0, 5);
            pieces[0, 6] = new ChessPieceKnight(this, EChessSide.WHITE, 0, 6);
            pieces[0, 7] = new ChessPieceRook(this, EChessSide.WHITE, 0, 7);
            pieces[1, 0] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 0);
            pieces[1, 1] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 1);
            pieces[1, 2] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 2);
            pieces[1, 3] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 3);
            pieces[1, 4] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 4);
            pieces[1, 5] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 5);
            pieces[1, 6] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 6);
            pieces[1, 7] = new ChessPiecePawn(this, EChessSide.WHITE, 1, 7);

            pieces[6, 0] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 0);
            pieces[6, 1] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 1);
            pieces[6, 2] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 2);
            pieces[6, 3] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 3);
            pieces[6, 4] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 4);
            pieces[6, 5] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 5);
            pieces[6, 6] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 6);
            pieces[6, 7] = new ChessPiecePawn(this, EChessSide.BLACK, 6, 7);
            pieces[7, 0] = new ChessPieceRook(this, EChessSide.BLACK, 7, 0);
            pieces[7, 1] = new ChessPieceKnight(this, EChessSide.BLACK, 7, 1);
            pieces[7, 2] = new ChessPieceBishop(this, EChessSide.BLACK, 7, 2);
            pieces[7, 3] = new ChessPieceQueen(this, EChessSide.BLACK, 7, 3);
            pieces[7, 4] = new ChessPieceKing(this, EChessSide.BLACK, 7, 4);
            pieces[7, 5] = new ChessPieceBishop(this, EChessSide.BLACK, 7, 5);
            pieces[7, 6] = new ChessPieceKnight(this, EChessSide.BLACK, 7, 6);
            pieces[7, 7] = new ChessPieceRook(this, EChessSide.BLACK, 7, 7);

        }

        public ChessPiece GetPiece(int row, int col)
        {
            if (row < 0 || col < 0 || row >= 8 || col >= 8)
                return null;

            return pieces[row, col];
        }
        public ChessPiece[,] GetPieces()
        {
            return pieces;
        }
        public void ClearBoard()
        {
            pieces = new ChessPiece[8,8];
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
            pieces[row, col] = piece;
        }
    }
}
