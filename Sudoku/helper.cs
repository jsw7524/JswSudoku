using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku
{
    public static class helper
    {
        public static void SaveToTxt(SudokuBoard board, string filename)
        {
            List<List<int>> data = new List<List<int>>();
            for (int i = 0; i < 9; i++)
            {
                List<int> tmp = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    tmp.Add(board[i, j]);
                }
                data.Add(tmp);
            }
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filename, json);
        }

        public static string GetBoardJson(SudokuBoard board)
        {
            List<List<int>> tmp = new List<List<int>>();

            for (int i=0;i<9;i++)
            {
                tmp.Add(board.GetRow(i).Select(c=>c.Value).ToList());
            }
            return "{\"board\":" + JsonConvert.SerializeObject(tmp) + "}";
        }

    }
}
