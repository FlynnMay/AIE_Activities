using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_28_AsteroidsRaylib
{
    class Player : GameObject
    {
        Program program;
        public Vector2 size = new Vector2(64, 64);
        public Vector2 velocity = new Vector2(0, 0);
        public Color currentPlayerColour = Color.WHITE;
        public Color playerColour = Color.WHITE;
        public Color shieldColour = Color.BLUE;
        public float accelerationSpeed = 0.1f;
        //public float rotation = 0.0f;
        public float rotationSpeed = 5.0f;
        public float maxSpeed = 15f;
        public float invTimer = 3f;
        public float invTimerReset = 3f;
        public int score = 0;
        public int lives = 3;
        public bool invulnerable = false;

        public Player(Program program, Vector2 pos, Vector2 size)
        {
            this.program = program;
            this.pos = pos;
            this.size = size;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                Rotate(-rotationSpeed);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                Rotate(rotationSpeed);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                velocity += dir * accelerationSpeed;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                velocity -= dir * accelerationSpeed;
            }

            // limiting player speed
            if (velocity.X > maxSpeed) velocity.X = maxSpeed;
            if (velocity.Y > maxSpeed) velocity.Y = maxSpeed;
            if (velocity.X < -maxSpeed) velocity.X = -maxSpeed;
            if (velocity.Y < -maxSpeed) velocity.Y = -maxSpeed;

            // deceleration
            if (velocity.X > 0) velocity.X -= 0.05f;
            if (velocity.Y > 0) velocity.Y -= 0.05f;
            if (velocity.X < 0) velocity.X += 0.05f;
            if (velocity.Y < 0) velocity.Y += 0.05f;

            // add velocity to positon
            pos += velocity;

            // wrap player around screen
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.Y > program.windowHeight) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.SpawnBullet(pos, dir);
            }

            // lives
            if (lives <= 0)
            {
                pos = new Vector2(program.windowWidth / 2, program.windowHeight / 2);
                velocity = new Vector2(0, 0);
                lives = 3;
                score -= 50;
                invulnerable = true;
            }

            if (invulnerable)
            {
                invTimer -= Raylib.GetFrameTime();
                if ((int)invTimer % 2 == 0 )
                {
                    currentPlayerColour = shieldColour;
                }
                else
                {
                    currentPlayerColour = playerColour;
                }
            }
            if (invTimer < 0.0f)
            {
                invTimer = invTimerReset;
                invulnerable = false;
                currentPlayerColour = playerColour;
            }
        }

        public Vector2 GetFacingDirection(float rotation)
        {
            return new Vector2(
                MathF.Cos((MathF.PI / 180) * rotation),
                MathF.Sin((MathF.PI / 180) * rotation)
            );
        }

        public void Draw()
        {
            var texture = Assets.shipTexture;
            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0, 0, texture.width, texture.height),
                new Rectangle(pos.X, pos.Y, size.X, size.Y),
                new Vector2(0.5f * size.X, 0.5f * size.Y),
                GetRotation(), currentPlayerColour);
            Raylib.DrawText(score.ToString(), 0, 0, 20, Color.WHITE);
            DrawScores(Color.WHITE);
        }

        private void DrawScores(Color colour)
        {
            int spacer = 0;
            for (int i = 0; i < lives; i++)
            {
                Raylib.DrawCircle(program.windowWidth - 15 + spacer, program.windowHeight - 15, 10, colour);
                spacer -= 30;
            }
        }
    }
}
