using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class StrategyOnlySquareRuleRow : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            var emptyCellsInRow = pvc.cell.parentRow.cells.Where(c => 0 == c.Value && !c.Equals(pvc.cell));
            if (emptyCellsInRow.Count()==0)
            {
                return pvc;
            }
            for (int i = 1; i < 10; i++)
            {
                if (pvc.possibleValues[i] >= 0)
                {
                    if (emptyCellsInRow.All(c=>c.parentColumn.ContainNumber(i)))
                    {
                        pvc.possibleValues[i]++;
                    }
                }
            }
            return pvc;
        }
    }
}

