using System;

namespace SodokuSolver.Strategies
{
    public class NakedPairsStrategy : ISodokuStrategy
    {
        private readonly SodokuMapper _sodokuMapper;

        public NakedPairsStrategy(SodokuMapper sodokuMapper)
        {
            _sodokuMapper = sodokuMapper;
        }

        public int[,] Solve(int[,] sodokuBoard)
        {
            for (int row = 0; row < sodokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sodokuBoard.GetLength(1); col++)
                {
                    EliminateNakedPairFromOthersInRow(sodokuBoard, row, col);
                    EliminateNakedPairFromOthersInCol(sodokuBoard, row, col);
                    EliminateNakedPairFromOthersInGroup(sodokuBoard, row, col);
                }
            }
            return sodokuBoard;
        }

        private void EliminateNakedPairFromOthersInRow(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInRow(sodokuBoard, givenRow, givenCol))
                return;

            for (int col = 0; col < sodokuBoard.GetLength(1); col++)
            {
                if (sodokuBoard[givenRow, col] != sodokuBoard[givenRow, givenCol] && sodokuBoard[givenRow, col].ToString().Length > 1)
                    EliminateNakedPair(sodokuBoard, sodokuBoard[givenRow, givenCol], givenRow, col);
            }
        }

        private void EliminateNakedPair(int[,] sodokuBoard, int valuesToEliminate, int eliminateFromRow, int eliminateFromCol)
        {
            var valuesToEliminateArray = valuesToEliminate.ToString().ToCharArray();
            foreach(var valueToEliminate in valuesToEliminateArray)
            {
                sodokuBoard[eliminateFromRow, eliminateFromCol] = Convert.ToInt32(sodokuBoard[eliminateFromRow, eliminateFromCol].ToString().Replace(valuesToEliminate.ToString(), string.Empty));
            }
        }

        private bool HasNakedPairInRow(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            for (int col = 0; col < sodokuBoard.GetLength(1); col++)
            {
                if (givenCol != col && IsNakedPair(sodokuBoard[givenRow, col], sodokuBoard[givenRow, givenCol]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairFromOthersInCol(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInCol(sodokuBoard, givenRow, givenCol))
                return;

            for (int row = 0; row < sodokuBoard.GetLength(1); row++)
            {
                if (sodokuBoard[row, givenCol] != sodokuBoard[givenRow, givenCol] && sodokuBoard[row, givenCol].ToString().Length > 1)
                    EliminateNakedPair(sodokuBoard, sodokuBoard[givenRow, givenCol], row, givenCol);
            }
        }

        private bool HasNakedPairInCol(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            for (int row = 0; row < sodokuBoard.GetLength(1); row++)
            {
                if (givenRow != row && IsNakedPair(sodokuBoard[row, givenCol], sodokuBoard[givenRow, givenCol]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairFromOthersInGroup(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            if (!HasNakedPairInGroup(sodokuBoard, givenRow, givenCol))
                return;

            var sodokuMap = _sodokuMapper.Find(givenRow, givenCol);

            for (int row = sodokuMap.StartRow; row < sodokuMap.StartRow + 2; row++)
            {
                for (int col = sodokuMap.StartCol; col < sodokuMap.StartCol + 2; col++)
                {
                    if (sodokuBoard[row, col].ToString().Length > 1 && sodokuBoard[row, col] != sodokuBoard[givenRow, givenCol])
                        EliminateNakedPair(sodokuBoard, sodokuBoard[givenRow, givenCol], givenRow, givenCol);
                }
            }
        }

        private bool HasNakedPairInGroup(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            for (int row = 0; row < sodokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sodokuBoard.GetLength(1); col++)
                {
                    var elementsSame = givenRow == row && givenCol == col;
                    var elementInSameBlock = _sodokuMapper.Find(givenRow, givenCol).StartRow == _sodokuMapper.Find(row, col).StartRow &&
                        _sodokuMapper.Find(givenRow, givenCol).StartCol == _sodokuMapper.Find(row, col).StartCol;

                    if (!elementsSame && elementInSameBlock && !IsNakedPair(sodokuBoard[givenRow, givenCol], sodokuBoard[row, col]))
                        return true;
                }
            }
            return false;
        }

        private bool IsNakedPair(int firstPair, int secondPair)
        {
            return firstPair.ToString().Length == 2 && firstPair.Equals(secondPair);
        }
    }
}