using System.Linq;

namespace Sudoku
{
    public class StrategyOtherColumns : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            int bx = cell.parentBlock.positionBlock.x;
            for (int n = 1; n < 10; n++)
            {
                if (cell.possibleValues[n] < 0)
                    continue;
                int times = 0;
                for (int r = 3 * bx; r < 3 * bx + 3; r++)
                {
                    if (r == cell.parentColumn.positionColumn.x)
                        continue;
                    if (board.Columns[r].ContainNumber(n) && !cell.parentRow.ContainNumber(n))
                        times += 1;
                }
                if (times == 2)
                {
                    cell.possibleValues[n] += 1;
                    int notEmpty = cell.parentBlock.GetColumn(cell.cellColumnRow.x).Where(c => c.Value > 0).Count();
                    if (notEmpty >= 2)
                    {
                        cell.possibleValues[n] += 1;
                    }
                    else if (notEmpty == 1)
                    {
                        var anotherEmpty = cell.parentBlock.GetColumn(cell.cellColumnRow.x).Where(c => c.Value == 0 && c != cell).FirstOrDefault();
                        if (anotherEmpty.parentRow.ContainNumber(n))
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
