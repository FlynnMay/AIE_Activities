using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_GameStates
{
    class GameState
    {
        protected Program program;

        public GameState(Program program)
        {
            this.program = program;
        }
        public virtual void Update()
        {
            // Empty
        }
        public virtual void Draw()
        {
            // Empty
        }
    }
}
