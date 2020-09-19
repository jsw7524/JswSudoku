using System;

namespace Sudoku
{
    public class SudokuRow : IValidatable
    {
        public SudokuCell[] cells = new SudokuCell[9];
        public int[,] data = null;
        public SudokuBoard parentBoard = null;
        public RowColumn positionRow = null;
        public SudokuRow(int[,] d, SudokuBoard p, RowColumn pos)
        {
            parentBoard = p;
            data = d;
            positionRow = pos;
            for (int i = 0; i < 9; i++)
            {
                cells[i] = parentBoard.Blocks[positionRow.y / 3, i / 3].cells[positionRow.y % 3, i % 3];
                cells[i].parentRow = this;
            }
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
