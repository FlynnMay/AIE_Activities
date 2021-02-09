using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace AIE_19_RayLibPong
{
    class Program
    {
        Ball ball;
        Ball ball2;
        Paddle lPaddle;
        Paddle rPaddle;
        int windowWidth = 800;
        int windowHeight = 450;
        bool endGame = false;
        List<Paddle> paddles = new List<Paddle>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunProgram();
        }
        private void RunProgram()
        {
            Raylib.InitWindow(800, 450, "Pong");
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

        private void ResetBall(Ball b)
        {
            b.pos.X = windowWidth / 2;
            b.pos.Y = windowHeight / 2;
            b.speed = ball.resetSpeed;
        }

        private void LoadGame()
        {
            ball = new Ball();
            ball.pos.X = windowWidth / 2;
            ball.pos.Y = windowHeight / 2;
            ball.dir.X = 0.707f;
            ball.dir.Y = 0.707f;

            ball2 = new Ball();
            ball2.pos.X = windowWidth / 2;
            ball2.pos.Y = windowHeight / 2;
            ball2.dir.X = -0.707f;
            ball2.dir.Y = -0.707f;

            lPaddle = new Paddle();
            lPaddle.name = "Left Player";
            lPaddle.pos.X = 10;
            lPaddle.pos.Y = windowHeight / 2.0f;
            lPaddle.upKey = KeyboardKey.KEY_W;
            lPaddle.downKey = KeyboardKey.KEY_S;

            rPaddle = new Paddle();
            rPaddle.name = "Right Player";
            rPaddle.pos.X = windowWidth - 10;
            rPaddle.pos.Y = windowHeight / 2.0f;
            rPaddle.upKey = KeyboardKey.KEY_UP;
            rPaddle.downKey = KeyboardKey.KEY_DOWN;

            paddles.Add(lPaddle);
            paddles.Add(rPaddle);
        }

        private void Update()
        {
            UpdateBall(ball);

            UpdateBall(ball2);

            UpdatePaddle(lPaddle);
            UpdatePaddle(rPaddle);
            HandlePaddleBallCollision(lPaddle, ball);
            HandlePaddleBallCollision(rPaddle, ball);

            HandlePaddleBallCollision(lPaddle, ball2);
            HandlePaddleBallCollision(rPaddle, ball2);
        }
        private void UpdateBall(Ball b)
        {
            b.pos += b.dir * b.speed * Raylib.GetFrameTime() * 60;

            if (b.pos.X < 0)
            {
                ResetBall(b);
                rPaddle.score += 1;
            }
            if (b.pos.X > windowWidth)
            {
                ResetBall(b);
                lPaddle.score += 1;
            }
            if (b.pos.Y < 0) b.dir.Y = -b.dir.Y;
            if (b.pos.Y > windowHeight) b.dir.Y = -b.dir.Y;
        }

        private void UpdatePaddle(Paddle p)
        {
            if (Raylib.IsKeyDown(p.upKey))
            {
                p.pos -= new Vector2(0, p.speed * Raylib.GetFrameTime() * 60);
            }
            if (Raylib.IsKeyDown(p.downKey))
            {
                p.pos += new Vector2(0, p.speed * Raylib.GetFrameTime() * 60);
            }
            if (p.pos.Y - (p.size.Y / 2) < 0) p.pos.Y = 0 + (p.size.Y / 2);
            if (p.pos.Y + (p.size.Y / 2) > windowHeight) p.pos.Y = windowHeight - (p.size.Y / 2);
        }

        private void HandlePaddleBallCollision(Paddle p, Ball b)
        {
            float top = p.pos.Y - p.size.Y / 2;
            float bottom = p.pos.Y + p.size.Y / 2;
            float right = p.pos.X + p.size.X / 2;
            float left = p.pos.X - p.size.X / 2;

            if (b.pos.Y > top && b.pos.Y < bottom && b.pos.X > left && b.pos.X < right)
            {
                b.dir.X = -b.dir.X;
                b.speed += 1f;
            }
        }

        private void DrawBall(Ball b)
        {
            Raylib.DrawCircle((int)b.pos.X, (int)b.pos.Y, b.radius, Color.WHITE);
        }

        private void DrawPaddle(Paddle p)
        {
            Raylib.DrawRectanglePro(new Rectangle(p.pos.X, p.pos.Y, p.size.X, p.size.Y), p.size / 2, 0.0f, Color.WHITE);
        }

        private void DrawScores(int x, int y, Paddle paddle, Color colour)
        {
            int spacer = 0;
            for (int i = 0; i < Paddle.scoreMax - paddle.score; i++)
            {
                Raylib.DrawCircle(x + spacer, y, paddle.scoreSize, colour);
                if (paddle.Equals(rPaddle))
                {
                    spacer += 30;
                }
                else
                {
                    spacer -= 30;
                }
            }

        }


        private void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            foreach (var paddle in paddles)
            {
                if (paddle.score <= 3)
                {
                    DrawBall(ball);
                    DrawBall(ball2);
                    DrawPaddle(lPaddle);
                    DrawPaddle(rPaddle);
                }
                else
                {
                    Raylib.DrawText(paddle.name + " Wins!", windowWidth / 2, windowHeight / 2, 50, Color.WHITE);
                }

            }

            DrawScores(0 + 50, windowHeight - 25, rPaddle, Color.BLUE);
            DrawScores(windowWidth - 50, windowHeight - 25, lPaddle, Color.RED);

            //Raylib.DrawText(lPaddle.score.ToString(), windowWidth / 4, 20, 20, Color.WHITE);
            //Raylib.DrawText(rPaddle.score.ToString(), windowWidth - (windowWidth / 4), 20, 20, Color.WHITE);

            Raylib.DrawFPS(10, 10);

            Raylib.EndDrawing();
        }
    }
}
