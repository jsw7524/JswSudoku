using System;
using System.Collections.Generic;

namespace Sudoku
{
    public interface ILocatable
    {
        Boolean ContainNumber(int n);
        IEnumerable<SudokuCell> GetRow(int y);
        IEnumerable<SudokuCell> GetColumn(int x);
    }
}
