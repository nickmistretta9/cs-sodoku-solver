using System;
using System.IO;
using System.Linq;

namespace SodokuSolver
{
    public class SodokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sodokuBoard = new int[9, 9];
            try
            {
                var sodokuBoardLines = File.ReadAllLines(filename);
                var row = 0;
                foreach(var sodokuBoardLine in sodokuBoardLines)
                {
                    string[] sodokuBoardLineElements = sodokuBoardLine.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach(var sodokuBoardLineElement in sodokuBoardLineElements)
                    {
                        sodokuBoard[row, col] = sodokuBoardLineElement.Equals(" ") ? 0 : Convert.ToInt16(sodokuBoardLineElement);
                        col++;
                    }
                    row++;
                }
            } catch(Exception ex)
            {
                throw new Exception("Something went wrong while reading the file: " + ex.Message);
            }
            return sodokuBoard;
        }
    }
}
