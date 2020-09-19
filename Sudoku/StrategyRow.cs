﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class StrategyRow : IStrategy
    {
        public PossibleValuesInCell Evaluate(SudokuBoard board, PossibleValuesInCell pvc)
        {
            foreach (var rc in pvc.cell.parentRow.cells)
            {
                if (0 != rc.Value)
                {
                    pvc.possibleValues[rc.Value] = -1;
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
