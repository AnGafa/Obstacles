using System;
using System.Collections.Generic;

namespace OOPGame
{
    class Game
    {
        private List<Barrier> barriers = new List<Barrier>();

        private List<Powerup> powerups = new List<Powerup>();

        private Player gamePlayer;

        const int X_SIZE = 70;
        const int Y_SIZE = 30;

        const int BARRIER_X_RAIL_LOW = 15;
        const int BARRIER_X_RAIL_HIGH = 60;

        const int BARRIER_Y_RAIL_LOW = 5;
        const int BARRIER_Y_RAIL_HIGH = 25;

        Board gameBoard = new Board(X_SIZE, Y_SIZE);


        private void AddBarrier(int initX, int initY, bool moveMode, bool movement)
        {
            Barrier b = new Barrier(gameBoard, initX, initY, moveMode, movement);
            barriers.Add(b);
        }

        private void AddPowerup(Powerup newPowerUp)
        {
            powerups.Add(newPowerUp);
        }

        public Game()
        {

            Console.WindowHeight = Y_SIZE + 1;
            Console.WindowWidth = X_SIZE + 1;
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;

            CreateGame();

        }

        private void MoveBarriers()
        {
            foreach (Barrier b in barriers)
            {
                b.Move();
            }
        }
        private void MovePowerups()
        {
            foreach (Powerup p in powerups)
            {
                p.Move();
            }
        }

        public void ExecuteGame()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            bool gameOverBarrier = false;
            bool gameOverPowerup = false;


            // main loop
            while (!gameOverBarrier && !gameOverPowerup)
            {
                dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalMilliseconds > 50)
                {
                    // move all barriers
                    MoveBarriers();

                    // move the player
                    gamePlayer.Move();
                        
                    gameOverPowerup = CheckPowerupHit();

                    MovePowerups();

                    gameOverBarrier = CollisionDetection();

                    dt1 = DateTime.Now;
                }

            }

            Console.Clear();
            if(gameOverBarrier)
                Console.WriteLine("You lost. You are weak");
            else if (gameOverPowerup)
                Console.WriteLine("You won. You are superman");


            Console.ReadLine();
        }

        private bool CheckPowerupHit()
        {
            Powerup hitPowerup = null;

            foreach (Powerup p in powerups)
            {
                if (this.gamePlayer.IsCollision(p))
                {
                    hitPowerup = p;
                    break;
                }
            }

            if (hitPowerup != null)
            {
                powerups.Remove(hitPowerup);
                Console.WriteLine(powerups.Count);
                
            }

            return powerups.Count < 1;
        }

        private bool CollisionDetection()
        {
            foreach (Barrier b in barriers)
            {
                if (this.gamePlayer.IsCollision(b))
                    return true;
            }

            return false;
        }


        Random rand = new Random();


        private Powerup CreatePowerup()
        {
            int randX, randY;


            do
            {
                randX = rand.Next(0, X_SIZE);
            }
            while ((randX == BARRIER_X_RAIL_LOW) || (randX == BARRIER_X_RAIL_HIGH));

            do
            {
                randY = rand.Next(0, Y_SIZE);
            }
            while ((randY == BARRIER_Y_RAIL_LOW) || (randY == BARRIER_Y_RAIL_HIGH));

            Powerup newPowerUp = new Powerup(gameBoard, randX, randY);

            return newPowerUp;

        }

        public void CreateGame()
        {
            AddBarrier(BARRIER_X_RAIL_LOW, 15, false, true);
            AddBarrier(BARRIER_X_RAIL_HIGH, 15, false, false);

            AddBarrier(35, BARRIER_Y_RAIL_LOW, true, true);
            AddBarrier(35, BARRIER_Y_RAIL_HIGH, true, false);

            for (int i = 0; i < 3; i++)
            {
                AddPowerup(CreatePowerup());
            }

            gamePlayer = new Player(this.gameBoard, 35, 15);
        }
    }
}
