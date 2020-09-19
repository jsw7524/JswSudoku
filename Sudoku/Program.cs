using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class RowColumn
    {
        public int y;
        public int x;
    }
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

    public class SudokuRow
    {
        public SudokuCell[] cells = new SudokuCell[9];
        public int[,] data = null;
        public SudokuBoard parentBoard = null;
        public RowColumn positionRow = null;
        public SudokuRow(int[,] d, SudokuBoard p, RowColumn pos)
        {
            parentBoard = p;
            data = d;
            positionRow = pos;
            for (int i = 0; i < 9; i++)
            {
                cells[i] = parentBoard.Blocks[positionRow.y / 3, i / 3].cells[positionRow.y % 3, i % 3];
            }
        }

    }

    public class SudokuBoard
    {
        public int[,] data = new int[9, 9];
        public SudokuBlock[,] Blocks = new SudokuBlock[3, 3];
        public SudokuRow[] Rows= new SudokuRow[9];
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
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
