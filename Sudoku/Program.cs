using Newtonsoft.Json;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataJson = @"[[0,0,0,0,2,9,0,0,0],[0,2,0,0,0,6,7,0,0],[0,7,0,0,0,0,0,0,0],[2,0,0,0,0,0,8,0,0],[0,0,0,8,9,0,1,0,0],[0,9,7,0,0,0,0,0,0],[0,0,0,0,7,0,9,0,8],[0,8,0,0,3,0,0,1,6],[0,6,4,0,8,0,3,0,2]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
        }
    }
}
