using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class StrategyOnlySquareRuleColumn : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            var emptyCellsInColumn = pvc.cell.parentColumn.cells.Where(c => 0 == c.Value && !c.Equals(pvc.cell));
            if (emptyCellsInColumn.Count() == 0)
            {
                return pvc;
            }
            for (int i = 1; i < 10; i++)
            {
                if (pvc.possibleValues[i] >= 0)
                {
                    if (emptyCellsInColumn.All(c => c.parentRow.ContainNumber(i)))
                    {
                        pvc.possibleValues[i]++;
                    }
                }
            }
            return pvc;
        }
    }
}
