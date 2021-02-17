using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_36_GameStates
{
    class SplashScreen :  GameState
    {
        float cooldownTimer = 3.0f;
        public SplashScreen(Program program) : base(program)
        {

        }
        public override void Update()
        {
            cooldownTimer -= Raylib.GetFrameTime();
            if (cooldownTimer < 0)
            {
                program.ChangeGameState(new MenuScreen(program));
            }
        }
        public override void Draw()
        {
            Raylib.DrawText("Splash Screen", 10, 10, 20, Color.GRAY);
        }
    }
}
