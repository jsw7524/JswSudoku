using System;
using System.Collections.Generic;
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

    }
}
