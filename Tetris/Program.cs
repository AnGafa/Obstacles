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

            Barrier o = new Barrier(b, 10, 5);
            Barrier o2 = new Barrier(b, 60, 15);

            Console.WindowHeight = Y_SIZE+1;
            Console.WindowWidth = X_SIZE;
            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            while (true)
            {
                dt2 = DateTime.Now;
                if (dt2.Subtract(dt1).TotalMilliseconds > 50)
                {
                    o.Move();
                    o2.Move();

                    dt1 = DateTime.Now;
                }
                
            }
        }
    }
}
