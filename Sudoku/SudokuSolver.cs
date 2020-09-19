using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{

    public class SudokuSolver
    {
        public List<IStrategy> Strategies = new List<IStrategy>();

        public IEnumerable<SudokuCell> GetEmptyCells(SudokuBoard board)
        {
            List<SudokuCell> result = new List<SudokuCell>();
            foreach (var row in board.Rows)
            {
                foreach (var cell in row.cells)
                {
                    if (0 == cell.Value)
                    {
                        result.Add(cell);
                    }
                }
            }
            return result;
        }

        public void AddStrategy(IStrategy stg)
        {
            Strategies.Add(stg);
        }

        public SudokuSolver()
        {
            StrategyColumn stgclm = new StrategyColumn();
            StrategyRow stgRow = new StrategyRow();
            StrategyBlock stgBlk = new StrategyBlock();
            this.AddStrategy(stgclm);
            this.AddStrategy(stgRow);
            this.AddStrategy(stgBlk);
        }

        public PossibleValuesInCell EvaluatePossibleValuesInCell(SudokuBoard board, SudokuCell c)
        {
            var pvc = new PossibleValuesInCell(c);
            foreach (var stg in Strategies)
            {
                stg.Evaluate(board, pvc);
            }
            return pvc;
        }


    }
}
