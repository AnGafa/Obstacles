using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    class Board
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public ConsoleColor[,] Colours { get; set; }

        public Board(int x, int y)
        {
            SizeX = x;
            SizeY = y;
            Colours = new ConsoleColor[SizeX, SizeY];
        }
    }
}
