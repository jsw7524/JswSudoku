namespace Sudoku
{
    public class SudokuBoard : IValidatable
    {
        public int[,] data = new int[9, 9];
        public SudokuBlock[,] Blocks = new SudokuBlock[3, 3];
        public SudokuRow[] Rows= new SudokuRow[9];
        public SudokuColumn[] Columns = new SudokuColumn[9];

        public int this[int y, int x]
        {
            get => Rows[y].cells[x].Value;
            set => Rows[y].cells[x].Value = value;
        }

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



        public bool ValidateNumbers()
        { 
            foreach (IValidatable b in Blocks)
            {
                if (false == b.ValidateNumbers())
                {
                    return false;
                }
            }
            foreach (IValidatable r in Rows)
            {
                if (false == r.ValidateNumbers())
                {
                    return false;
                }
            }
            foreach (IValidatable c in Columns)
            {
                if (false == c.ValidateNumbers())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
