using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver.Workers
{
    class SodokuBoardDisplayer
    {
        public void Display(string title, int[,] sodokuBoard)
        {
            if(!title.Equals(string.Empty))
                Console.WriteLine("{0} {1}", title, Environment.NewLine);

            for(int row=0; row<sodokuBoard.GetLength(0); row++)
            {
                Console.Write("|");
                for(int col=0; col<sodokuBoard.GetLength(1); col++)
                {
                    Console.Write("{0}{1}", sodokuBoard[row, col], "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
