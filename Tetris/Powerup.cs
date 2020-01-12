using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    class Powerup : GameItem
    {
        public Powerup(Board board, int initX, int initY)
        {
            x = initX;
            y = initY;
            colour = ConsoleColor.Yellow;
            b = board;
        }

        public void Move()
        {
            Erase();

            Draw();
        }

    }
}
