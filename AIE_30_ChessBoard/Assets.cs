using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace ChessGame
{
    static class Assets
    {
        public static Texture2D chessPieceTexture;

        // This is new, i'm using a dictionary as 2d lookup table
        public static Dictionary<EChessSide, Dictionary<ChessPiece.Type, Rectangle>> chessPieceSrcRects = new Dictionary<EChessSide, Dictionary<ChessPiece.Type, Rectangle>>();

        public static void Load()
        {
            chessPieceTexture = Raylib.LoadTexture("./assets/Chess_Pieces_Sprites.png");

            int spriteW = chessPieceTexture.width / 6;
            int spriteH = chessPieceTexture.height / 2;

            chessPieceSrcRects[EChessSide.WHITE] = new Dictionary<ChessPiece.Type, Rectangle>();
            chessPieceSrcRects[EChessSide.BLACK] = new Dictionary<ChessPiece.Type, Rectangle>();

            // because we only have 1 texture,
            // here im defining the src area for each of the sprites on the loaded texture.
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.PAWN] = new Rectangle(5 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.PAWN] = new Rectangle(5 * spriteW, 1 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.ROOK] = new Rectangle(4 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.ROOK] = new Rectangle(4 * spriteW, 1 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.KNIGHT] = new Rectangle(3 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.KNIGHT] = new Rectangle(3 * spriteW, 1 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.BISHOP] = new Rectangle(2 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.BISHOP] = new Rectangle(2 * spriteW, 1 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.KING] = new Rectangle(1 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.KING] = new Rectangle(1 * spriteW, 1 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.WHITE][ChessPiece.Type.QUEEN] = new Rectangle(0 * spriteW, 0 * spriteH, spriteW, spriteH);
            chessPieceSrcRects[EChessSide.BLACK][ChessPiece.Type.QUEEN] = new Rectangle(0 * spriteW, 1 * spriteH, spriteW, spriteH);


            
        }
    }
}
