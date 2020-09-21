using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class SudokuColumn : IValidatable, ILocatable
    {
        public SudokuCell[] cells = new SudokuCell[9];
        public int[,] data = null;
        public SudokuBoard parentBoard = null;
        public RowColumn positionColumn = null;
        public SudokuColumn(int[,] d, SudokuBoard p, RowColumn pos)
        {
            parentBoard = p;
            data = d;
            positionColumn = pos;
            for (int i = 0; i < 9; i++)
            {
                cells[i] = parentBoard.Blocks[i / 3,positionColumn.x / 3].cells[i % 3, positionColumn.x % 3];
                cells[i].parentColumn = this;
            }
        }
        public bool ContainNumber(int n)
        {
            return cells.Any(c => c.Value == n);
        }

        public IEnumerable<SudokuCell> GetColumn(int x)
        {
            List<SudokuCell> tmp = new List<SudokuCell>(cells);
            return tmp;
        }

        public IEnumerable<SudokuCell> GetRow(int y)
        {
            List<SudokuCell> tmp = new List<SudokuCell> { cells[y] };
            return tmp;
        }

        public bool ValidateNumbers()
        {
            Boolean[] numbers = new Boolean[10];
            for (int i = 0; i < 9; i++)
            {
                numbers[cells[i].Value] = true;
            }
            for (int i = 1; i < 10; i++)
            {
                if (false == numbers[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
