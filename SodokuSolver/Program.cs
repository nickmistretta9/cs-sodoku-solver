using SodokuSolver.Strategies;
using SodokuSolver.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SodokuMapper sodokuMapper = new SodokuMapper();
                SodokuBoardStateManager sodokuBoardStateManager = new SodokuBoardStateManager();
                SodokuSolverEngine sodokuSolverEngine = new SodokuSolverEngine(sodokuBoardStateManager, sodokuMapper);
                SodokuFileReader sodokuFileReader = new SodokuFileReader();
                SodokuBoardDisplayer sodokuBoardDisplayer = new SodokuBoardDisplayer();

                Console.Write("Please enter the filename containing the Sodoku Puzzle: ");
                var fileName = Console.ReadLine();

                var sodokuBoard = sodokuFileReader.ReadFile(fileName);

                sodokuBoardDisplayer.Display("Initial State", sodokuBoard);

                bool isSodokuSolved = sodokuSolverEngine.Solve(sodokuBoard);
                sodokuBoardDisplayer.Display("Final State", sodokuBoard);

                Console.WriteLine(isSodokuSolved ? "You have successfully solved this sodoku puzzle." : "Unforunately, current algorithm(s) were not enough to solve the current sodoku puzzle.");

            } catch(Exception ex)
            {
                Console.WriteLine("{0} : {1}", "Sodoku puzzle could not be solved because there was an error:", ex.Message);
            }
        }
    }
}
