using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_36_GameStates
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        string windowTitle = "GameStateManagement";

        public string filename = "./Highscores.scrs";
        GameState currentGameState = null;
        public List<ScoreEntry> scores = new List<ScoreEntry>();
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
            currentGameState = new SplashScreen(this);
            DeserialiseScores();
        }

        void Update()
        {
            if (currentGameState != null)
                currentGameState.Update();
        }
        void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawFPS(10, windowHeight - 20);

            if (currentGameState != null)
                currentGameState.Draw();

            Raylib.EndDrawing();
        }
        public void ChangeGameState(GameState newGameState)
        {
            currentGameState = newGameState;
        }
        void DeserialiseScores()
        {
            var fileInfo = new FileInfo(filename);
            var dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);
            using (StreamReader sr = File.OpenText(filename))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] entry = line.Split(' ');
                    scores.Add(new ScoreEntry(entry[0], Int32.Parse(entry[1])));
                }
            }
        }
    }
}
