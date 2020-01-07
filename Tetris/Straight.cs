using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Straight : Tetrominoe
    {
        public Straight(Board board) : base(board)
        {
        }

        public override void Paint(bool erase)
        {
            // if (erase == true) paintColour = Black else paintColour = colour
            ConsoleColor paintColour = (erase) ? ConsoleColor.Black : colour;
            int paintX = x;
            int paintY = y;
            Console.ForegroundColor = paintColour;
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(paintX, paintY);
                Console.Write("█");
                b.Colours[paintX, paintY] = paintColour;

                if (orientation == 0) // horizontal
                    paintX++;
                else
                    paintY++;
            }
        }

        public override string CanMakeMove(int proposedOrientation, int proposedX, int proposedY)
        {
            string canMakeMove = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                if (proposedY >= 20 || b.Colours[proposedX, proposedY] != ConsoleColor.Black)
                {
                    canMakeMove = "Freeze";
                    break;
                }

                if (orientation == 0)
                    proposedX++;
                else
                    proposedY++;
            }
            return canMakeMove;
        }
    }
}
