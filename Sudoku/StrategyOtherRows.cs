using System.Linq;

namespace Sudoku
{
    public class StrategyOtherRows : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            int by = cell.parentBlock.positionBlock.y;
            for (int n = 1; n < 10; n++)
            {
                if (cell.possibleValues[n] < 0)
                    continue;
                int times = 0;
                for (int r = 3 * by; r < 3 * by + 3; r++)
                {
                    if (r == cell.parentRow.positionRow.y)
                        continue;
                    if (board.Rows[r].ContainNumber(n) && !cell.parentColumn.ContainNumber(n))
                        times += 1;
                }
                if (times == 2)
                {
                    cell.possibleValues[n] += 1;
                    int notEmpty = cell.parentBlock.GetRow(cell.cellColumnRow.y).Where(c => c.Value > 0).Count() ;
                    if (notEmpty >= 2)
                    {
                        cell.possibleValues[n] += 1;
                    }
                    else if (notEmpty == 1)
                    {
                        var anotherEmpty = cell.parentBlock.GetRow(cell.cellColumnRow.y).Where(c => c.Value == 0 && c != cell).FirstOrDefault();
                        if (anotherEmpty.parentColumn.ContainNumber(n))
                        {
                            cell.possibleValues[n] += 1;
                        }
                    }
                }
            }
            return cell;
        }
    }
}
