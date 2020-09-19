using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class StrategyBlock : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            foreach (var cc in pvc.cell.parentBlock.cells)
            {
                if (0 != cc.Value)
                {
                    pvc.possibleValues[cc.Value] = -1;
                }
            }
            for (int i = 1; i < 10; i++)
            {
                if (pvc.possibleValues[i] >= 0)
                {
                    pvc.possibleValues[i]++;
                }
            }
            return pvc;
        }
    }
}
