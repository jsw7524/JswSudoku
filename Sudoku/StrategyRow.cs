namespace Sudoku
{
    public class StrategyRow : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            foreach (var rc in cell.parentRow.cells)
            {
                if (0 != rc.Value)
                {
                    cell.possibleValues[rc.Value] = -1;
                }
            }
            for (int i = 1; i < 10; i++)
            {
                if (cell.possibleValues[i] >= 0)
                {
                    cell.possibleValues[i]++;
                }
            }
            return cell;
        }
    }
}
