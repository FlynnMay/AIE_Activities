using System;
using System.Collections.Generic;
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
        // Bullet[] bullets = new Bullet[100];
        List<Bullet> bullets = new List<Bullet>();
        //Asteroid[] asteroids = new Asteroid[100];
        List<Asteroid> asteroids = new List<Asteroid>();
        List<Asteroid> asteroidsToAdd = new List<Asteroid>();


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
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i] = null;
            }

            // initialise asteroids to be null
            for (int i = 0; i < asteroids.Count; i++)
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

            List<Bullet> bulletsToRemove = new List<Bullet>();
            List<Asteroid> asteroidsToRemove = new List<Asteroid>();

            // update all bullets
            foreach (var bullet in bullets)
            {
                if (bullet.isAlive)
                {
                    bullet.Update();
                }
                else
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            // remove all dead bullets
            foreach (var b in bulletsToRemove)
                bullets.Remove(b);



            // update all asteroids
            foreach (var asteroid in asteroids)
            {
                if (asteroid.isAlive)
                {
                    asteroid.Update();
                }
                else
                {
                    asteroidsToRemove.Add(asteroid);
                }
            }


            // remove all dead asteroids
            foreach (var a in asteroidsToRemove)
                asteroids.Remove(a);

            foreach (var bullet in bullets)
            {
                foreach (var asteroid in asteroids)
                {
                    DoBulletAsteroidCollison(bullet, asteroid);
                }
            }
            foreach (var asteroid in asteroidsToAdd)
            {
                asteroids.Add(asteroid);
            }
            asteroidsToAdd.Clear();
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
            bullets.Add(bullet);
            //for (int i = 0; i < bullets.Count; i++)
            //{
            //    if (bullets[i] == null)
            //    {
            //        bullets[i] = bullet;
            //        break;
            //    }
            //}
        }

        public void SpawnNewAsteroid()
        {
            Random random = new Random();
            int side = random.Next(0, 4);

            float rot = (float)random.NextDouble() * MathF.PI * 2.0f;
            Vector2 dir = new Vector2(MathF.Cos(rot), MathF.Sin(rot));
            float radius = 40;

            // left wall spawn
            if (side == 0) asteroids.Add(SpawnAsteroid(new Vector2(0, random.Next(0, windowHeight)), dir, radius));

            // top wall spawn
            if (side == 1) asteroids.Add(SpawnAsteroid(new Vector2(random.Next(0, windowWidth), 0), dir, radius));

            // right wall spawn
            if (side == 2) asteroids.Add(SpawnAsteroid(new Vector2(windowWidth, random.Next(0, windowHeight)), dir, radius));

            // top wall spawn
            if (side == 1) asteroids.Add(SpawnAsteroid(new Vector2(random.Next(0, windowWidth), windowHeight), dir, radius));
        }
        public Asteroid SpawnAsteroid(Vector2 pos, Vector2 dir, float radius)
        {
            Asteroid asteroid = new Asteroid(this, pos, dir);
            asteroid.radius = radius;
            return asteroid;

            //for (int i = 0; i < asteroids.Count; i++)
            //{
            //    if (asteroids[i] == null)
            //    {
            //        asteroids[i] = asteroid;
            //        break;
            //    }
            //}
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
                    asteroidsToAdd.Add(SpawnAsteroid(asteroid.pos, asteroid.dir, asteroid.radius / 2));
                    asteroidsToAdd.Add(SpawnAsteroid(asteroid.pos, -asteroid.dir, asteroid.radius / 2));
                }
                bullet.isAlive = false;
                asteroid.isAlive = false;
            }
        }
    }
}
