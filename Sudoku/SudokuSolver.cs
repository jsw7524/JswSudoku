using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class ValueWithProbability
    {
        public SudokuCell cell;
        public int value;
        public double probability;
    }

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

        public IEnumerable<ValueWithProbability> MakeCellValueWithProbability(SudokuBoard board, IEnumerable<SudokuCell> emptyCells)
        {
            List<PossibleValuesInCell> possibleValuesInCell = new List<PossibleValuesInCell>();
            foreach (var c in emptyCells)
            {
                possibleValuesInCell.Add(EvaluatePossibleValuesInCell(board, c));
            }
            List<ValueWithProbability> result = new List<ValueWithProbability>();
            foreach (var pvc in possibleValuesInCell)
            {
                double sum = pvc.possibleValues.Where(c => c > 0).Sum();
                for (int i = 1; i < 10; i++)
                {
                    if (pvc.possibleValues[i] > 0)
                    {
                        var vp = new ValueWithProbability() { cell = pvc.cell, value = i, probability = pvc.possibleValues[i] / sum };
                        result.Add(vp);
                    }
                }
            }
            return result;
        }

        public SudokuBoard Solve(SudokuBoard board)
        {
            var emptyCells = GetEmptyCells(board);
            return board;
        }
        int depth = 0;
        public Boolean BestFirstSearch(SudokuBoard board)
        {

            var emptyCells = GetEmptyCells(board);
            if (0 == emptyCells.Count())
            {
                if (board.ValidateNumbers())
                {
                    return true;
                }
                return false;
            }

            var ordered = MakeCellValueWithProbability(board, emptyCells).OrderByDescending(c => c.probability);
            if (0 == ordered.Count())
            {
                return false;
            }
            if (emptyCells.Count() > ordered.Count())
            {
                return false;
            }
            if (0 == ordered.Last().probability)
            {
                return false;
            }

            foreach (var cv in ordered)
            {
                Debug.WriteLine("depth:" + depth + "value:" + cv.value + "YX:" + cv.cell.absY + " " + cv.cell.absX);

                cv.cell.Value = cv.value;
                depth += 1;
                if (BestFirstSearch(board))
                {
                    return true;
                }
                depth -= 1;
                cv.cell.Value = 0;
            }
            return false;
        }
    }
}
