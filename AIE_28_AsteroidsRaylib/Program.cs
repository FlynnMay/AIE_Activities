using System;
using System.Numerics;
using Raylib_cs;

namespace AIE_28_AsteroidsRaylib
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Asteroids";

        float asteroidSpawnCooldown = 4.0f;
        float asteroidSpawnCooldownReset = 4.0f;

        Player player;
        Bullet[] bullets = new Bullet[100];
        Asteroid[] asteroids = new Asteroid[100];

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }
        private void RunGame()
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

        private void LoadGame()
        {
            Assets.LoadAssets();

            player = new Player(this,
                new Vector2(windowWidth / 2, windowHeight / 2),
                new Vector2(64, 64));

            // initialise bullets to be null
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = null;
            }

            // initialise asteroids to be null
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i] = null;
            }
        }
        private void Update()
        {
            asteroidSpawnCooldown -= Raylib.GetFrameTime();
            if (asteroidSpawnCooldown < 0.0f)
            {
                SpawnNewAsteroid();
                asteroidSpawnCooldown = asteroidSpawnCooldownReset;
            }
            player.Update();

            // update all bullets
            foreach (var bullet in bullets)
            {
                if (bullet != null)
                {
                    bullet.Update();
                }
            }
            // update all asteroids
            foreach (var asteroid in asteroids)
            {
                if (asteroid != null)
                {
                    asteroid.Update();
                }
            }

            foreach (var bullet in bullets)
            {
                foreach (var asteroid in asteroids)
                {
                    DoBulletAsteroidCollison(bullet, asteroid);
                }
            }
        }
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.GRAY);

            player.Draw();

            // draw all bullets
            foreach (var bullet in bullets)
            {
                if (bullet != null)
                {
                    bullet.Draw();
                }
            }

            // draw all asteroids
            foreach (var asteroid in asteroids)
            {
                if (asteroid != null)
                {
                    asteroid.Draw();
                }
            }

            Raylib.EndDrawing();
        }

        public void SpawnBullet(Vector2 pos, Vector2 dir)
        {
            Bullet bullet = new Bullet(this, pos, dir);
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] == null)
                {
                    bullets[i] = bullet;
                    break;
                }
            }
        }

        public void SpawnNewAsteroid()
        {
            Random random = new Random();
            int side = random.Next(0, 4);

            float rot = (float)random.NextDouble() * MathF.PI * 2.0f;
            Vector2 dir = new Vector2(MathF.Cos(rot), MathF.Sin(rot));
            float radius = 40;

            // left wall spawn
            if (side == 0) SpawnAsteroid(new Vector2(0, random.Next(0, windowHeight)), dir, radius);

            // top wall spawn
            if (side == 1) SpawnAsteroid(new Vector2(random.Next(0, windowWidth), 0), dir, radius);

            // right wall spawn
            if (side == 2) SpawnAsteroid(new Vector2(windowWidth, random.Next(0, windowHeight)), dir, radius);

            // top wall spawn
            if (side == 1) SpawnAsteroid(new Vector2(random.Next(0, windowWidth), windowHeight), dir, radius);
        }
        public void SpawnAsteroid(Vector2 pos, Vector2 dir, float radius)
        {
            Asteroid asteroid = new Asteroid(this, pos, dir);
            asteroid.radius = radius;
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null)
                {
                    asteroids[i] = asteroid;
                    break;
                }
            }
        }

        public void DoBulletAsteroidCollison(Bullet bullet, Asteroid asteroid)
        {
            if (bullet == null || asteroid == null)
                return;

            float distance = (bullet.pos - asteroid.pos).Length();
            if (distance < asteroid.radius)
            {
                if (asteroid.radius > 10)
                {
                    SpawnAsteroid(asteroid.pos, asteroid.dir, asteroid.radius / 2);
                    SpawnAsteroid(asteroid.pos, -asteroid.dir, asteroid.radius / 2);
                }
                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i] == bullet)
                    {
                        bullets[i] = null;
                        break;
                    }
                }
                for (int i = 0; i < asteroids.Length; i++)
                {
                    if (asteroids[i] == asteroid)
                    {
                        asteroids[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
