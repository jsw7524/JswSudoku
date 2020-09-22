namespace Sudoku
{
    public interface IStrategy
    {
        SudokuCell Evaluate(SudokuBoard board, SudokuCell cell);
    }
}
