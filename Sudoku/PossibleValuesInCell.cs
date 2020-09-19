namespace Sudoku
{
    public class PossibleValuesInCell
    {
        public SudokuCell cell;
        public int[] possibleValues = new int[10]; //negative values mean impossible.

        public PossibleValuesInCell(SudokuCell c)
        {
            cell = c;
        }
    }
}
