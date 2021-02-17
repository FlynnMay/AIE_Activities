using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_GameStates
{
    class PlayGameScreen : GameState
    {
        int buttonPressCount = 0;
        float cooldownTimer = 10.0f;
        public PlayGameScreen(Program program) : base(program)
        {

        }
        public override void Update()
        {
            cooldownTimer -= Raylib.GetFrameTime();
            if (cooldownTimer < 0)
            {
                program.scores.Add(new ScoreEntry("Flynn", buttonPressCount));
                program.ChangeGameState(new GameOverScreen(program));
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                buttonPressCount++;
        }
        public override void Draw()
        {
            Raylib.DrawText("Play Game Screen", 10, 10, 20, Color.GRAY);
            Raylib.DrawText($"Press Count: {buttonPressCount}", 10, 30, 20, Color.GRAY);
            Raylib.DrawText($"Time: {cooldownTimer}", 10, 50, 20, Color.GRAY);
        }
    }
}
