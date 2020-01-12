using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{

    class Player : GameItem
    {

        public Player(Board board, int initX, int initY)
        {
            x = initX;
            y = initY;
            colour = ConsoleColor.Red;
            b = board;
        }

        private void MovePlayer(){
        
            ConsoleKey keypressed;

            keypressed = Console.ReadKey().Key;

            if(keypressed == ConsoleKey.UpArrow & this.y > 0)
                    this.y--;

            if(keypressed == ConsoleKey.DownArrow & this.y < b.SizeY)
                    this.y++;
            
            if(keypressed == ConsoleKey.RightArrow & this.x < b.SizeX)
                    this.x++;
            if(keypressed == ConsoleKey.LeftArrow & this.x > 0)
                    this.x--;
        }
        
        public void Move()
        {
            Erase();

            if(Console.KeyAvailable)
            {
                MovePlayer();
            }

            Draw();
        }
    }
}
