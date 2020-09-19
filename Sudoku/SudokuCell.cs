namespace Sudoku
{
    public class SudokuCell
    {
        //int[] numbers = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int Value = 0;
        public int[,] data = null;
        public int absX;
        public int absY;
        RowColumn cellColumnRow = null;
        SudokuBlock parentBlock = null;
        public SudokuCell(int[,] d, SudokuBlock p, RowColumn blockRC, RowColumn cellRC)
        {
            parentBlock = p;
            data = d;
            this.cellColumnRow = cellRC;
            var tmp = helper.absCell(blockRC, cellRC);
            absX = tmp.x;
            absY = tmp.y;
            Value = data[absY, absX];
        }
    }
}
