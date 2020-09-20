using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class StrategyOtherRows : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            int by = pvc.cell.parentBlock.positionBlock.y;
            for (int n = 1; n < 10; n++)
            {
                if (pvc.possibleValues[n] < 0)
                    continue;
                int times=0;
                for (int r = 3 * by; r < 3 * by + 3; r++)
                {
                    if (r== pvc.cell.parentRow.positionRow.y)
                        continue;
                    if(board.Rows[r].ContainNumber(n))
                        times += 1;
                }
                if (times==2)
                {
                    pvc.possibleValues[n] += 1;
                }
            }
            return pvc;
        }
    }
}
