using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{

    /// <summary>
    /// A barrier class
    /// </summary>
    class Barrier
    {
        protected int x;
        protected int y;
        protected ConsoleColor colour;
        protected Board b;

        private bool isMovingDefault;


        /// <summary>
        /// the movement mode of the obstacle
        /// if true movement is left <-> right
        /// if false movement is up <-> down
        /// </summary>
        private bool movementMode;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        public Barrier(Board board, int initX, int initY, bool moveMode, bool movement)
        {
            x = initX;
            y = initY;
            colour = ConsoleColor.Green;
            b = board;

            this.isMovingDefault = movement;

            this.movementMode = moveMode;
        }


        public void Move()
        {
            if (this.movementMode == true)
                MoveHorizontal();
            else
                MoveVertical();
        }

        private void MoveHorizontal()
        {
            int z = 0;
            if (x > 70)
                z = 0;
            
            if (x >= b.SizeX)
                this.isMovingDefault = false;
            else if (x <= 0)
                this.isMovingDefault = true;

            Erase();

            if (!isMovingDefault)
                x--;
            else
                x++;

            Draw();
        }

        private void MoveVertical()
        {
            if (b.SizeY <= y)
                this.isMovingDefault = false;
            else if (0 >= y)
                this.isMovingDefault = true;
    
            Erase();

            if (isMovingDefault)
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
