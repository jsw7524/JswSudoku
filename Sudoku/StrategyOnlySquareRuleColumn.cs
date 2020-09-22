using System.Linq;

namespace Sudoku
{
    class StrategyOnlySquareRuleColumn : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            var emptyCellsInColumn = cell.parentColumn.cells.Where(c => 0 == c.Value && !c.Equals(cell));
            if (emptyCellsInColumn.Count() == 0)
            {
                return cell;
            }
            for (int i = 1; i < 10; i++)
            {
                if (cell.possibleValues[i] >= 0)
                {
                    if (emptyCellsInColumn.All(c => c.parentRow.ContainNumber(i)))
                    {
                        cell.possibleValues[i]++;
                    }
                }
            }
            return cell;
        }
    }
}
