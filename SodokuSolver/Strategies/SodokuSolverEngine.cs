using SodokuSolver.Workers;
using System.Collections.Generic;
using System.Linq;

namespace SodokuSolver.Strategies
{
    public class SodokuSolverEngine
    {
        private readonly SodokuBoardStateManager _sodokuBoardStateManager;
        private readonly SodokuMapper _sodokuMapper;

        public SodokuSolverEngine(SodokuBoardStateManager sodokuBoardStateManager, SodokuMapper sodokuMapper)
        {
            _sodokuBoardStateManager = sodokuBoardStateManager;
            _sodokuMapper = sodokuMapper;
        }

        public bool Solve(int[,] sodokuBoard)
        {
            List<ISodokuStrategy> strategies = new List<ISodokuStrategy>() {
            };

            var currentState = _sodokuBoardStateManager.GenerateState(sodokuBoard);
            var nextState = _sodokuBoardStateManager.GenerateState(strategies.First().Solve(sodokuBoard));

            while(!_sodokuBoardStateManager.IsSolved(sodokuBoard) && currentState != nextState)
            {
                currentState = nextState;
                foreach(var strategy in strategies)
                {
                    nextState = _sodokuBoardStateManager.GenerateState(strategy.Solve(sodokuBoard));
                }
            }

            return _sodokuBoardStateManager.IsSolved(sodokuBoard);
        }
    }
}
