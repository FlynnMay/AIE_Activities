using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIE_36_GameStates
{
    class GameOverScreen : GameState
    { 
        public GameOverScreen(Program program) : base(program)
        {

        }
        public override void Update()
        {

        }
        public override void Draw()
        {
            SerialiseScores();
            int yOffset = 10;
            foreach (var entry in program.scores)
            {
                Raylib.DrawText($"{entry.name}: {entry.score}", program.windowWidth / 2, 0 + yOffset, 20, Color.BLACK);
                yOffset += 20;
            }
            Raylib.DrawText("Game Over", 10, 10, 20, Color.RED);
        }
        void SerialiseScores()
        {
            var fileInfo = new FileInfo(program.filename);
            var dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);
            using (StreamWriter sw = File.CreateText(program.filename))
            {
                foreach (var entry in program.scores)
                {
                    sw.WriteLine($"{entry.name} {entry.score}");
                }
            }
        }
    }
}
