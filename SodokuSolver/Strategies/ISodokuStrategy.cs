using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver.Strategies
{
    interface ISodokuStrategy
    {
        int[,] Solve(int[,] sodokuBoard);
    }
}
