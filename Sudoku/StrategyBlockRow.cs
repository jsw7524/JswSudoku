using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class StrategyBlockRow : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var block = board.Blocks[i, j];
                    Dictionary<int, List<int>> dictNumRow = new Dictionary<int, List<int>>();
                    for (int r = 0; r < 3; r++)
                    {
                        foreach (var rc in block.GetRow(r))
                        {
                            for (int k = 1; k < 10; k++)
                            {
                                if (rc.possibleValues[k] >= 0)
                                {
                                    if (!dictNumRow.ContainsKey(k))
                                    {
                                        dictNumRow[k] = new List<int>();
                                    }
                                    dictNumRow[k].Add(r);
                                }

                            }
                        }
                    }

                    for (int key = 1; key < 10; key++)
                    {
                        if (dictNumRow.ContainsKey(key))
                        {
                            var tmpList = dictNumRow[key];
                            if (tmpList.All(c => c == tmpList[0]))
                            {
                                var notPossibleValue=board.GetRow(3 * block.positionBlock.y + tmpList[0]);

                                foreach (var nc in notPossibleValue)
                                {
                                    if (nc.parentBlock!= block)
                                    {
                                        nc.possibleValues[key] = -1;
                                    }

                                }
                            }
                        }

                    }

                }
            }
            return null;
        }
    }
}
