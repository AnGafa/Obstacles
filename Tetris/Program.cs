using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            const int X_SIZE = 70;
            const int Y_SIZE = 30;

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            Board b = new Board(X_SIZE, Y_SIZE);

            Barrier v1 = new Barrier(b, 10, 5);
            Barrier v2 = new Barrier(b, 60, 15);

            Barrier h1 = new Barrier(b, 5, 15);
            Barrier h2 = new Barrier(b, 20, 5);

            Console.WindowHeight = Y_SIZE+1;
            Console.WindowWidth = X_SIZE+5;
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            while (true)
            {
                dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalMilliseconds > 50)
                {
                    v1.MoveVertical();
                    v2.MoveVertical();

                    h1.MoveHorizontal();
                    h2.MoveHorizontal();

                    dt1 = DateTime.Now;
                }
                
            }
        }
    }
}
