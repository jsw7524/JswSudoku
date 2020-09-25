using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class StrategyBlockColumn : IStrategy
    {
        public SudokuCell Evaluate(SudokuBoard board, SudokuCell cell)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var block = board.Blocks[i, j];
                    Dictionary<int, List<int>> dictNumColumn = new Dictionary<int, List<int>>();
                    for (int col = 0; col < 3; col++)
                    {
                        foreach (var rc in block.GetColumn(col))
                        {
                            for (int k = 1; k < 10; k++)
                            {
                                if (rc.possibleValues[k] >= 0)
                                {
                                    if (!dictNumColumn.ContainsKey(k))
                                    {
                                        dictNumColumn[k] = new List<int>();
                                    }
                                    dictNumColumn[k].Add(col);
                                }

                            }
                        }
                    }

                    for (int key = 1; key < 10; key++)
                    {
                        if (dictNumColumn.ContainsKey(key))
                        {
                            var tmpList = dictNumColumn[key];
                            if (tmpList.All(c => c == tmpList[0]))
                            {
                                var notPossibleValue = board.GetRow(3 * block.positionBlock.x + tmpList[0]);

                                foreach (var nc in notPossibleValue)
                                {
                                    if (nc.parentBlock != block)
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
