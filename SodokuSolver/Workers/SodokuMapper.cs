using SodokuSolver.Data;

namespace SodokuSolver
{
    public class SodokuMapper
    {
        public SodokuMap Find(int givenRow, int givenCol)
        {
            SodokuMap sodokuMap = new SodokuMap();

            if((givenRow >= 0 && givenRow <= 2) && (givenCol >=0 && givenCol <= 2))
            {
                sodokuMap.StartRow = 0;
                sodokuMap.StartCol = 0;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenCol >= 3 && givenCol <= 5))
            {
                sodokuMap.StartRow = 0;
                sodokuMap.StartCol = 3;
            }
            else if ((givenRow >= 0 && givenRow <= 2) && (givenCol >= 6 && givenCol <= 8))
            {
                sodokuMap.StartRow = 0;
                sodokuMap.StartCol = 6;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 0 && givenCol <= 2))
            {
                sodokuMap.StartRow = 3;
                sodokuMap.StartCol = 0;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 3 && givenCol <= 5))
            {
                sodokuMap.StartRow = 3;
                sodokuMap.StartCol = 3;
            }
            else if ((givenRow >= 3 && givenRow <= 5) && (givenCol >= 6 && givenCol <= 8))
            {
                sodokuMap.StartRow = 3;
                sodokuMap.StartCol = 6;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 0 && givenCol <= 2))
            {
                sodokuMap.StartRow = 6;
                sodokuMap.StartCol = 0;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 3 && givenCol <= 5))
            {
                sodokuMap.StartRow = 6;
                sodokuMap.StartCol = 3;
            }
            else if ((givenRow >= 6 && givenRow <= 8) && (givenCol >= 6 && givenCol <= 8))
            {
                sodokuMap.StartRow = 6;
                sodokuMap.StartCol = 6;
            }
            return sodokuMap;
        }
    }
}
