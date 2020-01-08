using System;
using System.Collections.Generic;

namespace OOPGame
{
    class Game
    {
        private List<Barrier> barriers = new List<Barrier>();

        private Player gamePlayer;


        const int X_SIZE = 70;
        const int Y_SIZE = 30;
        Board gameBoard = new Board(X_SIZE, Y_SIZE);



        private void AddBarrier(int initX, int initY, bool moveMode, bool movement)
        {
            Barrier b = new Barrier(gameBoard, initX, initY, moveMode, movement);
            barriers.Add(b);
        }

        public Game()
        {

            Console.WindowHeight = Y_SIZE + 1;
            Console.WindowWidth = X_SIZE + 5;
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;

            CreateGame();

        }

        private void MoveBarriers()
        {
            foreach(Barrier b in barriers)
            {
                b.Move();
            }
        }

        public void ExecuteGame()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            while (true)
            {
                dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalMilliseconds > 50)
                {
                    MoveBarriers();

                    gamePlayer.Move();

                    dt1 = DateTime.Now;
                }

            }
        }


        public void CreateGame()
        {
            AddBarrier(10, 15, false, true);
            AddBarrier(60, 15, false, false);

            AddBarrier(35, 25, true, true);
            AddBarrier(35, 5, true, false);

            gamePlayer = new Player(this.gameBoard, 35, 15);

        }



    }
}
