using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class StrategyOtherColumns : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            int bx = pvc.cell.parentBlock.positionBlock.x;
            for (int n = 1; n < 10; n++)
            {
                if (pvc.possibleValues[n] < 0)
                    continue;
                int times = 0;
                for (int r = 3 * bx; r < 3 * bx + 3; r++)
                {
                    if (r == pvc.cell.parentColumn.positionColumn.x)
                        continue;
                    if (board.Columns[r].ContainNumber(n))
                        times += 1;
                }
                if (times == 2)
                {
                    pvc.possibleValues[n] += 1;
                }
            }
            return pvc;
        }
    }
}
