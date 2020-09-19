namespace Sudoku
{
    public class SudokuBlock
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
    }
}
