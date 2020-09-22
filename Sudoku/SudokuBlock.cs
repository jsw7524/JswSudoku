using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class SudokuBlock : IValidatable, ILocatable
    {
        public SudokuCell[,] cells = new SudokuCell[3, 3];
        public int[,] data = null;
        public RowColumn positionBlock;
        public SudokuBoard parentBoard = null;
        public SudokuBlock(int[,] d, SudokuBoard p, RowColumn pos)
        {
            parentBoard = p;
            data = d;
            positionBlock = pos;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = new SudokuCell(data, this, positionBlock, new RowColumn { y = i, x = j });
                }
            }
        }

        public bool ContainNumber(int n)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j].Value == n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IEnumerable<SudokuCell> GetColumn(int x)
        {
            List<SudokuCell> tmp = new List<SudokuCell> { cells[0, x], cells[1, x], cells[2, x] };
            return tmp;
        }

        public IEnumerable<SudokuCell> GetRow(int y)
        {
            List<SudokuCell> tmp = new List<SudokuCell> { cells[y, 0], cells[y, 1], cells[y, 2] };
            return tmp;
        }

        public bool ValidateNumbers()
        {
            Boolean[] numbers = new Boolean[10];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    numbers[cells[i, j].Value] = true;
                }
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
