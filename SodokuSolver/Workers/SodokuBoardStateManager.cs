using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver.Workers
{
    class SodokuBoardStateManager
    {
        public string GenerateState(int[,] sodokuBoard)
        {
            StringBuilder key = new StringBuilder();

            for (int row = 0; row < sodokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sodokuBoard.GetLength(1); col++)
                {
                    key.Append(sodokuBoard[row, col]);
                }
            }

            return key.ToString();
        }

        public bool IsSolved(int[,] sodokuBoard)
        {
            for (int row = 0; row < sodokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sodokuBoard.GetLength(1); col++)
                {
                    if (sodokuBoard[row, col] == 0 || sodokuBoard[row, col].ToString().Length > 1)
                        return false;
                }
            }
            return true;
        }
    }
}
