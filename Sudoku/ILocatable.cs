using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface ILocatable
    {
        Boolean ContainNumber(int n);
        IEnumerable<SudokuCell> GetRow(int y);
        IEnumerable<SudokuCell> GetColumn(int x);
    }
}
