namespace Sudoku
{
    public class StrategyColumn : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            foreach (var cc in cell.parentColumn.cells)
            {
                if (0 != cc.Value)
                {
                    cell.possibleValues[cc.Value] = -1;
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
