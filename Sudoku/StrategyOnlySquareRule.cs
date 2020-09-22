using System.Linq;

namespace Sudoku
{
    class StrategyOnlySquareRuleRow : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            var emptyCellsInRow = cell.parentRow.cells.Where(c => 0 == c.Value && !c.Equals(cell));
            if (emptyCellsInRow.Count() == 0)
            {
                return cell;
            }
            for (int i = 1; i < 10; i++)
            {
                if (cell.possibleValues[i] >= 0)
                {
                    if (emptyCellsInRow.All(c => c.parentColumn.ContainNumber(i)))
                    {
                        cell.possibleValues[i]++;
                    }
                }
            }
            return cell;
        }
    }
}

