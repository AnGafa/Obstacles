﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Barrier
    {
        protected int x;
        protected int y;
        protected ConsoleColor colour;
        protected Board b;

        private bool isMovingDown;

        public Barrier(Board board, int initX, int initY)
        {
            x = initX;
            y = initY;
            colour = ConsoleColor.Green;
            b = board;

            isMovingDown = true;

        }

        public void Move()
        {
            if (b.SizeY <= y)
                this.isMovingDown = false;
            else if (0 >= y)
                this.isMovingDown = true;
    
            Erase();

            if (isMovingDown)
                y++;
            else
                y--;

            Draw();
        }

        private void Draw()
        {
            Paint(false);
        }

        private void Erase()
        {
            Paint(true);
        }

        public virtual void Paint(bool erase)
        {
            // if we want to erase set the color to black, otherwise set to green
            ConsoleColor paintColour = (erase) ? ConsoleColor.Black : colour;
            
            // get obstacle x and y coordinates
            int paintX = x;
            int paintY = y;

            // set the color to paint
            Console.ForegroundColor = paintColour;
            // set location to paint
            Console.SetCursorPosition(paintX, paintY);
            // now paint
            Console.Write("█");
        }
    }
}