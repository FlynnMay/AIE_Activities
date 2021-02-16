using ChessGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AIE_31_ChessBoard
{
    public class GameManager
    {
        string filename = "./savefile.sav";
        public GameManager()
        {
            var fileInfo = new FileInfo(filename);
            var dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);
        }
        public void SaveGame(ChessPiece[,] board)
        {
            using (StreamWriter sw = File.CreateText(filename))
            {
                int counter = 0;
                foreach (var piece in board)
                {
                    if (counter % 8 == 0 && counter != 0)
                    {
                        sw.WriteLine("");
                    }
                    if (piece != null)
                    {
                        Console.WriteLine($"{piece.GetPieceType()} {piece.GetRow()}");

                            string p = piece.GetId() + " ";
                            sw.Write(piece.GetSide() == EChessSide.BLACK ? p.ToLower() : p);                        
                    }
                    else
                    {
                        sw.Write('*' + " ");
                    }
                    counter++;
                }
            }
        }
        public void LoadGame(ChessPiece[,] pieces, ChessBoard board)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                char s = '0';
                int x = 0;
                int y = 0;
                ChessPiece cp;
                while (sr.Peek() >= 0)
                {
                    if (counter % 8 == 0 && counter != 0)
                    {
                        sw.WriteLine("");
                    }

                    s = (char)sr.Read();
                    if (s.ToString().ToUpper() == ChessPiece.Id.B.ToString()) 
                        pieces[x, y] = new ChessPieceBishop(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                    if (s.ToString().ToUpper() == ChessPiece.Id.H.ToString()) 
                        pieces[x, y] = new ChessPieceKnight(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                    if (s.ToString().ToUpper() == ChessPiece.Id.K.ToString()) 
                        pieces[x, y] = new ChessPieceKnight(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                    s = (char)sr.Read();
                    if (s.ToString().ToUpper() == ChessPiece.Id.P.ToString()) 
                        pieces[x, y] = new ChessPiecePawn(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                    if (s.ToString().ToUpper() == ChessPiece.Id.Q.ToString()) 
                        pieces[x, y] = new ChessPieceQueen(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                    if (s.ToString().ToUpper() == ChessPiece.Id.R.ToString()) 
                        pieces[x, y] = new ChessPieceRook(board, 
                            Char.IsUpper(s) ? EChessSide.WHITE : EChessSide.BLACK, y,x);
                }
            }
        }
    }
}
