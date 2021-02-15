using System;
using Raylib_cs;
using System.Numerics;

namespace ChessGame
{
    class Program
    {
        int windowWidth = 800;
        int windowHeight = 450;
        string windowTitle = "Chess Game";

        ChessBoard board;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);

            LoadGame();

            while(!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            Assets.Load();

            board = new ChessBoard();
        }

        void Update()
        {
            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                var mousePos = Raylib.GetMousePosition();
                int mouseXIndex = (int)((mousePos.X - board.pos.X) / board.tileSize);
                int mouseYIndex = (int)((mousePos.Y - board.pos.Y) / board.tileSize);

                var selected = board.GetSelected();
                if (selected != null && selected.IsValidMove(mouseYIndex, mouseXIndex))
                {
                    selected.MoveTo(mouseYIndex, mouseXIndex);
                }
                else
                {
                    board.SelectTile(mouseYIndex, mouseXIndex);
                }
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            DrawGameBoard();
            DrawGamePieces();
            DrawSelectedPiece(board.GetSelected());

            Raylib.EndDrawing();
        }

        void DrawGameBoard()
        {
            int xPos = (int)board.pos.X;
            int yPos = (int)board.pos.Y;
            int ts = (int)board.tileSize;

            Color light = new Color(254, 205, 158, 255);
            Color dark = new Color(208, 139, 69, 255);

            
            // Draw the checkered grid
            for (int y=0; y<8; y++)
            {
                for(int x=0; x<8; x++)
                {
                    Color col = (y % 2 == 0 ? (x % 2 == 0 ? light : dark) : (x % 2 == 0 ? dark : light));
                    Raylib.DrawRectangle(xPos + x * ts, yPos + y * ts, ts, ts, col);
                }
            }

            // Draw the column identifier (a b c d e f g h) at the top of the board
            for (int i = 0; i < 8; i++)
            {
                char c = (char)('a' + i);
                Raylib.DrawText(c.ToString(), (ts/2) + xPos + i * ts, yPos-16, 14, Color.BLACK);
            }


            // Draw the row identifier (1 2 3 4 5 6 7 8) along the left side of the board
            for (int i = 0; i < 8; i++)
            {
                Raylib.DrawText((i+1).ToString(), xPos - 14, (ts / 2) + xPos + i * ts, 14, Color.BLACK);
            }
        }

        void DrawGamePieces()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    var piece = board.GetPiece(y, x);
                    if (piece == null)
                        continue;

                    Rectangle src = Assets.chessPieceSrcRects[piece.GetSide()][piece.GetPieceType()];

                    float xPos = x * board.tileSize + board.pos.X;
                    float yPos = y * board.tileSize + board.pos.Y;
                    var dst = new Rectangle(xPos, yPos, board.tileSize, board.tileSize);

                    Raylib.DrawTexturePro(Assets.chessPieceTexture, src, dst, Vector2.Zero, 0, Color.WHITE);
                }
            }
        }

        void DrawSelectedPiece(ChessPiece selected)
        {
            if (selected == null)
                return;

            float xPos = board.pos.X + selected.GetCol() * board.tileSize;
            float yPos = board.pos.Y + selected.GetRow() * board.tileSize;

            Raylib.DrawRectangleLinesEx(new Rectangle(xPos, yPos, board.tileSize, board.tileSize), 3, Color.BLACK);

            // for the selected tile.
            // Draw a circle in the valid squares that it can move to.
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (selected.IsValidMove(y, x))
                    {
                        xPos = board.pos.X + x * board.tileSize + (board.tileSize / 2.0f);
                        yPos = board.pos.Y + y * board.tileSize + (board.tileSize / 2.0f);
                        Raylib.DrawCircle((int)xPos, (int)yPos, 4, Color.BLACK);
                    }
                }
            }
        }
    }
}
