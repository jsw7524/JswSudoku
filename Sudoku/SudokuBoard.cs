namespace Sudoku
{
    public class SudokuBoard
    {
        public int[,] data = new int[9, 9];
        public SudokuBlock[,] Blocks = new SudokuBlock[3, 3];
        public SudokuRow[] Rows= new SudokuRow[9];

        public SudokuColumn[] Columns = new SudokuColumn[9];

        public SudokuBoard(int[,] d)
        {
            data = d.Clone() as int[,];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Blocks[i, j] = new SudokuBlock(data, this, new RowColumn { y = i, x = j });
                }
            }
            for (int i = 0; i < 9; i++)
            {
                Rows[i] = new SudokuRow(data, this, new RowColumn { y = i, x = 0 });
            }
            for (int i = 0; i < 9; i++)
            {
                Columns[i] = new SudokuColumn(data, this, new RowColumn { y = 0, x = i });
            }
        }
    }
}
