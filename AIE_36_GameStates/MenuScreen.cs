using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_GameStates
{
    class MenuScreen : GameState
    {
        public MenuScreen(Program program) : base(program)
        {

        }
        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.ChangeGameState(new PlayGameScreen(program));
            }
        }
        public override void Draw()
        {
            Raylib.DrawText("Menu Screen", 10, 10, 20, Color.GRAY);
        }
    }
}
