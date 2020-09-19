namespace Sudoku
{
    public static class helper
    {
        public static RowColumn absCell(RowColumn b, RowColumn c)
        {
            RowColumn result = new RowColumn();
            result.y = 3 * b.y + c.y;
            result.x = 3 * b.x + c.x;
            return result;
        }
    }
}
