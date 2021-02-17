using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class ChessPiece
    {
        public enum Type
        {
            PAWN,
            KNIGHT,
            BISHOP,
            ROOK,
            QUEEN,
            KING
        }

        protected ChessBoard board;

        EChessSide side;
        int row;
        int col;
        Type type;

        public ChessPiece(ChessBoard board, EChessSide side, Type type, int row, int col)
        {
            this.board = board;
            this.side = side;
            this.type = type;
            this.row = row;
            this.col = col;
        }

        public virtual bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetCol()
        {
            return col;
        }

        public Type GetPieceType()
        {
            return type;
        }

        public EChessSide GetSide()
        {
            return side;
        }

        public void MoveTo(int row, int col)
        {
            board.SetBoardPiece(this.row, this.col, null);
            this.row = row;
            this.col = col;
            board.SetBoardPiece(this.row, this.col, this);
        }

    }

    class ChessPiecePawn : ChessPiece
    {
        public ChessPiecePawn(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.PAWN, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            if (GetSide() == EChessSide.WHITE)
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() + 1 == targetRow)
                        return true;
                }
            }
            else
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() - 1 == targetRow)
                        return true;
                }
            }

            return false;
        }
    }

    class ChessPieceRook : ChessPiece
    {
        public ChessPieceRook(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.ROOK, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null)
                return false;
            if (!(targetCol == GetCol() || targetRow == GetRow()))
                return false;
            int dX = GetCol() - targetCol;
            int dY = GetRow() - targetRow;
            if (dX > 0) dX = 1;
            if (dX < 0) dX = -1;
            if (dY > 0) dY = 1;
            if (dY < 0) dY = -1;
            int cX = targetCol;
            int cY = targetRow;
            while (!(cX == GetCol() && cY == GetRow()) && cX >= 0 && cX < 8 && cY >= 0 && cY < 8)
            {
                var pieceInSpot = board.GetPiece(cY, cX);
                if (pieceInSpot != null)
                {
                    return false;
                }
                cX += dX;
                cY += dY;
            }

            return true;
        }
    }
    class ChessPieceKnight : ChessPiece
    {
        public ChessPieceKnight(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.KNIGHT, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }
    }
    class ChessPieceBishop : ChessPiece
    {
        public ChessPieceBishop(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.BISHOP, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }
    }
    class ChessPieceQueen : ChessPiece
    {
        public ChessPieceQueen(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.QUEEN, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }
    }
    class ChessPieceKing : ChessPiece
    {
        public ChessPieceKing(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.KING, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }
    }
}
