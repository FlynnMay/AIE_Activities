using System;
using System.Numerics;
using Raylib_cs;

namespace AIE_27_Classes
{
    class Program
    {
        Sprite sprite;
        GameSettings gs = new GameSettings();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunProgram();
        }
        private void RunProgram()
        {
            Raylib.InitWindow(gs.windowWidth, gs.windowHeight, gs.windowTitle);
            //Raylib.SetTargetFPS(60);

            LoadGame();
            while (!Raylib.WindowShouldClose())
            {
                // UPDATE LOGIC
                Update();
                // DRAWING LOGIC
                Draw();
            }
            Raylib.CloseWindow();
        }

        private void LoadGame()
        {
            sprite = new Sprite(new Vector2(gs.windowWidth / 2, gs.windowHeight / 2), 0.5f, 0);
        }
        private void Update()
        {
        }
        private void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.DrawTextureEx(sprite.texture, sprite.position, sprite.rotation, sprite.size, Color.WHITE);
            Raylib.ClearBackground(Color.BLACK);

            Raylib.EndDrawing();
        }
    }
}
