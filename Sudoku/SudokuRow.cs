namespace Sudoku
{
    public class SudokuRow
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
            }
        }
    }
}
