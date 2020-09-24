using System;
using System.Collections.Generic;
using System.Linq;

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
            this.AddStrategy(new StrategyColumn());
            this.AddStrategy(new StrategyRow());
            this.AddStrategy(new StrategyBlock());
            this.AddStrategy(new StrategyOtherRows());
            this.AddStrategy(new StrategyOtherColumns());
            this.AddStrategy(new StrategyOnlySquareRuleRow());
            this.AddStrategy(new StrategyOnlySquareRuleColumn());
        }

        public void EvaluatePossibleValuesInCell(SudokuBoard board, IEnumerable<SudokuCell> cells)
        {
            foreach (var c in cells)
            {
                for (int i = 0; i < 10; i++)
                {
                    c.possibleValues[i] = 0;
                }
            }
            foreach (var stg in Strategies)
            {
                foreach (var c in cells)
                {
                    stg.Evaluate(board, c);
                }
            }
            return ;
        }

        public IEnumerable<ValueWithProbability> MakeCellValueWithProbability(SudokuBoard board, IEnumerable<SudokuCell> emptyCells)
        {
            EvaluatePossibleValuesInCell(board,emptyCells);
            List <ValueWithProbability> result = new List<ValueWithProbability>();
            foreach (var c in emptyCells)
            {
                double sum = c.possibleValues.Where(v => v > 0).Sum();
                for (int i = 1; i < 10; i++)
                {
                    if (c.possibleValues[i] > 0)
                    {
                        var vp = new ValueWithProbability() { cell = c, value = i, probability = c.possibleValues[i] / sum };
                        result.Add(vp);
                    }
                }
            }
            return result;
        }

        public SudokuBoard Solve(SudokuBoard board)
        {
            if (BestFirstSearch(board))
                return board;
            return null;
        }
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
            foreach (var cv in ordered)
            {
                //Debug.WriteLine("depth:" + depth + "value:" + cv.value + "YX:" + cv.cell.absY + " " + cv.cell.absX);
                cv.cell.Value = cv.value;
                if (BestFirstSearch(board))
                {
                    return true;
                }
                cv.cell.Value = 0;
            }
            return false;
        }
    }
}
