namespace Sudoku
{
    public class SudokuColumn
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
            }
        }
    }
}
