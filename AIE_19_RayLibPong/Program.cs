using Raylib_cs;
using System;
using System.Numerics;

namespace AIE_19_RayLibPong
{
    class Ball
    {
        public Vector2 dir = new Vector2();
        public Vector2 pos = new Vector2();
        public float speed = 5.0f;
        public float resetSpeed = 5.0f;
        public float radius = 10.0f;
    }
    class Paddle
    {
        public Vector2 pos = new Vector2();
        public Vector2 size = new Vector2(10, 100);
        public float speed = 5.0f;
        public int score = 0;
        public KeyboardKey upKey;
        public KeyboardKey downKey;
    }

    class Program
    {
        Ball ball;
        Paddle lPaddle;
        Paddle rPaddle;
        int windowWidth = 800;
        int windowHeight = 450;
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

        private void ResetBall()
        {
            ball.pos.X = windowWidth / 2;
            ball.pos.Y = windowHeight / 2;
            ball.speed = ball.resetSpeed;
        }

        private void LoadGame()
        {
            ball = new Ball();
            ball.pos.X = windowWidth / 2;
            ball.pos.Y = windowHeight / 2;
            ball.dir.X = 0.707f;
            ball.dir.Y = 0.707f;

            lPaddle = new Paddle();
            lPaddle.pos.X = 10;
            lPaddle.pos.Y = windowHeight / 2.0f;
            lPaddle.upKey = KeyboardKey.KEY_W;
            lPaddle.downKey = KeyboardKey.KEY_S;
            
            rPaddle = new Paddle();
            rPaddle.pos.X = windowWidth - 10;
            rPaddle.pos.Y = windowHeight / 2.0f;
            rPaddle.upKey = KeyboardKey.KEY_UP;
            rPaddle.downKey = KeyboardKey.KEY_DOWN;
        }

        private void Update()
        {
            UpdateBall(ball);
            UpdatePaddle(lPaddle);
            UpdatePaddle(rPaddle);
            HandlePaddleBallCollision(lPaddle, ball);
            HandlePaddleBallCollision(rPaddle, ball);
        }
        private void UpdateBall(Ball b)
        {
            b.pos += b.dir * b.speed * Raylib.GetFrameTime() * 60;

            if (b.pos.X < 0) 
            {
                ResetBall();
                rPaddle.score += 1;
            }
            if (b.pos.X > windowWidth)
            {
                ResetBall();
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

        private void Draw()
        {
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.BLACK);

            DrawBall(ball);
            DrawPaddle(lPaddle);
            DrawPaddle(rPaddle);

            Raylib.DrawText(lPaddle.score.ToString(), windowWidth / 4, 20, 20, Color.WHITE);
            Raylib.DrawText(rPaddle.score.ToString(), windowWidth - (windowWidth / 4), 20, 20, Color.WHITE);

            Raylib.DrawFPS(10, 10);

            Raylib.EndDrawing();
        }
    }
}
