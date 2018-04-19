using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodokuSolver.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SodokuSolver.Test.Unit.Strategies
{
    [TestClass]
    public class NakedPairsStrategyTest
    {
        private readonly ISodokuStrategy _nakedPairsStrategy = new NakedPairsStrategy(new SodokuMapper());
        [TestMethod]
        public void ShouldEliminateNumbersInRowBasedOnNakedPair()
        {
            int[,] sodokuBoard =
            {
                { 1, 2, 34, 5, 34, 6, 7, 348, 9 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var solvedSodokuBoard = _nakedPairsStrategy.Solve(sodokuBoard);
            Assert.IsTrue(solvedSodokuBoard[0, 7] == 8);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInColBasedOnNakedPair()
        {
            int[,] sodokuBoard =
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 24, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 5, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 6, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 24, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 7, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 249, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var solvedSodokuBoard = _nakedPairsStrategy.Solve(sodokuBoard);
            Assert.IsTrue(solvedSodokuBoard[8, 0] == 9);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInGroup1BasedOnNakedPair()
        {
            int[,] sodokuBoard =
            {
                { 1, 2, 3, 0, 0, 0, 0, 0, 0 },
                { 45, 6, 7, 0, 0, 0, 0, 0, 0 },
                { 8, 45, 459, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var solvedSodokuBoard = _nakedPairsStrategy.Solve(sodokuBoard);
            Assert.IsTrue(solvedSodokuBoard[2, 2] == 9);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInGroup5BasedOnNakedPair()
        {
            int[,] sodokuBoard =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 7, 8, 9, 0, 0, 0 },
                { 0, 0, 0, 12, 3, 4, 0, 0, 0 },
                { 0, 0, 0, 6, 12, 125, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            var solvedSodokuBoard = _nakedPairsStrategy.Solve(sodokuBoard);
            Assert.IsTrue(solvedSodokuBoard[5, 5] == 5);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInGroup9BasedOnNakedPair()
        {
            int[,] sodokuBoard =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 2, 3 },
                { 0, 0, 0, 0, 0, 0, 4, 56, 56 },
                { 0, 0, 0, 0, 0, 0, 567, 8, 9 }
            };

            var solvedSodokuBoard = _nakedPairsStrategy.Solve(sodokuBoard);
            Assert.IsTrue(solvedSodokuBoard[8, 6] == 7);
        }
    }
}
