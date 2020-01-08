using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetrominoe
    {
        protected int x;
        protected int y;
        protected int orientation;
        protected ConsoleColor colour;
        protected Board b;

        Random r = new Random();

        public Tetrominoe(Board board)
        {
            x = 10;
            y = 5;
            orientation = 0; // 0 horizontal
            colour = (ConsoleColor)r.Next(1, 10);
            b = board;
        }

        //public string Drop()
        //{
        //    Erase();
        //    string canMakeMove = CanMakeMove(orientation, x, y + 1);
        //    if (canMakeMove == string.Empty)
        //        y++;
        //    Draw();
        //    return canMakeMove;
        //}

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
        }

        public virtual string CanMakeMove(int proposedOrientation, int proposedX, int proposedY)
        {
            return string.Empty;
        }
    }
}
