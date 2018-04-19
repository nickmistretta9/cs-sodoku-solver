using System;
using System.Linq;

namespace SodokuSolver.Strategies
{
    public class SimpleMarkupStrategy : ISodokuStrategy
    {
        private readonly SodokuMapper _sodokuMapper;

        public SimpleMarkupStrategy(SodokuMapper sodokuMapper)
        {
            _sodokuMapper = sodokuMapper;
        }

        public int[,] Solve(int[,] sodokuBoard)
        {
            for (int row = 0; row < sodokuBoard.GetLength(0); row++)
            {
                for (int col = 0; col < sodokuBoard.GetLength(1); col++)
                {
                    if (sodokuBoard[row, col] == 0 || sodokuBoard[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(sodokuBoard, row, col);
                        var possibilitiesInGroup = GetPossibilitiesInGroup(sodokuBoard, row, col);
                        sodokuBoard[row, col] = GetPossibilityIntersection(possibilitiesInRowAndCol, possibilitiesInGroup);
                    }
                }
            }
            return sodokuBoard;
        }

        private int GetPossibilitiesInRowAndCol(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for(int col=0; col<9; col++)
            {
                if (IsValidSingle(sodokuBoard[givenRow, col]))
                    possibilities[sodokuBoard[givenRow, col] - 1] = 0;
            }

            for (int row = 0; row < 9; row++)
            {
                if (IsValidSingle(sodokuBoard[row, givenCol]))
                    possibilities[sodokuBoard[row, givenCol] - 1] = 0;
            }

            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilitiesInGroup(int[,] sodokuBoard, int givenRow, int givenCol)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sodokuMap = _sodokuMapper.Find(givenRow, givenCol);
            for (int row = sodokuMap.StartRow; row < sodokuMap.StartRow + 2; row++)
            {
                for (int col = sodokuMap.StartCol; col < sodokuMap.StartCol + 2; col++)
                {
                    if(IsValidSingle(sodokuBoard[row, col]))
                    {
                        possibilities[sodokuBoard[row, col] - 1] = 0;
                    }
                }
            }
            return Convert.ToInt32(String.Join(string.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityIntersection(int possibilitiesInRowAndCol, int possibilitiesInGroup)
        {
            var possibilitiesInRowAndColCharArray = possibilitiesInRowAndCol.ToString().ToCharArray();
            var possibilitiesInGroupCharArray = possibilitiesInGroup.ToString().ToCharArray();
            var possibilitiesSubset = possibilitiesInRowAndColCharArray.Intersect(possibilitiesInGroupCharArray);
            return Convert.ToInt32(String.Join(string.Empty, possibilitiesSubset));
        }

        private bool IsValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length == 1;
        }
    }
}
