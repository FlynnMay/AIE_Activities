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

                        string p = piece.GetPieceType().ToString().First() + " ";
                        if (piece.GetPieceType() == ChessPiece.Type.KNIGHT)
                        {
                            p = piece.GetSide() == EChessSide.BLACK ? "h" + " " : "H" + " ";
                        }
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

        public void LoadGame(ChessBoard board)
        {

            List<string> lines = new List<string>();
            board.ClearBoard();
            var pieces = board.GetPieces();

            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    pieces[y, x] = null;

            using (StreamReader sr = File.OpenText(filename))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                    lines.Add(s.Replace(" ",""));
            }

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    char c = lines[y][x];
                    if (c == '*')
                        continue;

                    EChessSide side = char.IsLower(c) ? EChessSide.BLACK : EChessSide.WHITE;
                    c = char.ToLower(c);

                    if (c == 'p') pieces[y, x] = new ChessPiecePawn(board, side, y, x);
                    if (c == 'k') pieces[y, x] = new ChessPieceKing(board, side, y, x);
                    if (c == 'h') pieces[y, x] = new ChessPieceKnight(board, side, y, x);
                    if (c == 'b') pieces[y, x] = new ChessPieceBishop(board, side, y, x);
                    if (c == 'r') pieces[y, x] = new ChessPieceRook(board, side, y, x);
                    if (c == 'q') pieces[y, x] = new ChessPieceQueen(board, side, y, x);
                }
            }
        }
    }
}
