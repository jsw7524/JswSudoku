namespace Sudoku
{
    public class SudokuCell
    {
        //int[] numbers = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int Value = 0;
        public int[,] data = null;
        public int absX;
        public int absY;
        public RowColumn cellColumnRow = null;
        public SudokuBlock parentBlock = null;
        public SudokuRow parentRow = null;
        public SudokuColumn parentColumn = null;
        public SudokuCell(int[,] d, SudokuBlock p, RowColumn blockRC, RowColumn cellRC)
        {
            parentBlock = p;
            data = d;
            this.cellColumnRow = cellRC;
            absX = 3 * blockRC.x + cellRC.x;
            absY = 3 * blockRC.y + cellRC.y;
            Value = data[absY, absX];
        }
    }
}
