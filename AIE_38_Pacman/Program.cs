﻿using System;
using Raylib_cs;

namespace AIE_38_Pacman
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "PacMan";

        IGameState gameState;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }
        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }
            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            Assets.LoadAssets();
            gameState = new GameLevelScreen(this);
        }

        void Update()
        {
            if (gameState != null)
                gameState.Update();
        }
        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            if (gameState != null)
                gameState.Draw();

            Raylib.DrawFPS(10, windowHeight - 20);

            Raylib.EndDrawing();
        }
    }
}
