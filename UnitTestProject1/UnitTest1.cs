﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sudoku;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestSudokuBoard
    {
        string dataJson = @"[
[4, 3, 1, 2, 5, 7, 6, 9, 8], 
[2, 5, 8, 6, 3, 9, 1, 7, 4], 
[6, 7, 9, 1, 4, 8, 3, 5, 2], 
[1, 2, 5, 4, 9, 6, 8, 3, 7], 
[8, 4, 6, 3, 7, 5, 2, 1, 9], 
[7, 9, 3, 8, 1, 2, 5, 4, 6], 
[3, 1, 2, 7, 6, 4, 9, 8, 5], 
[5, 6, 4, 9, 8, 3, 7, 2, 1], 
[9, 8, 7, 5, 2, 1, 4, 6, 3]]";


        string invalidJson = @"[
[4, 3, 1, 2, 5, 7, 6, 9, 8], 
[2, 5, 8, 6, 3, 9, 1, 7, 4], 
[6, 7, 9, 1, 4, 8, 3, 5, 2], 
[1, 2, 5, 4, 9, 6, 8, 3, 7], 
[8, 4, 6, 3, 5, 5, 2, 1, 9], 
[7, 9, 3, 8, 1, 2, 5, 4, 6], 
[3, 1, 2, 7, 6, 4, 9, 8, 5], 
[5, 6, 4, 9, 8, 3, 7, 2, 1], 
[9, 8, 7, 5, 2, 1, 4, 6, 3]]";

        int[,] invalid = null;
        int[,] data = null;

        public UnitTestSudokuBoard()
        {
            data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            invalid = JsonConvert.DeserializeObject<int[,]>(invalidJson);
        }

        [TestMethod]
        public void TestMethod1()
        {
            int[,] a = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int[,] b = a.Clone() as int[,];
            a[0, 1] = 8;
            Assert.AreNotEqual(a[0, 1], b[0, 1]);
            Assert.AreEqual(a[1, 1], b[1, 1]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string json = "[[1,2],[3,4]]";
            int[,] a = JsonConvert.DeserializeObject<int[,]>(json);
            Assert.AreEqual(4, a[1, 1]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(4, board.Blocks[0, 0].cells[0, 0].Value);
        }

        [TestMethod]
        public void TestMethod4()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(3, board.Blocks[2, 2].cells[2, 2].Value);
        }

        [TestMethod]
        public void TestMethod5()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(5, board.Blocks[0, 0].cells[1, 1].Value);
        }

        [TestMethod]
        public void TestMethod6()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(2, board.Blocks[2, 2].cells[1, 1].Value);
        }
        [TestMethod]
        public void TestMethod7()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(7, board.Blocks[1, 1].cells[1, 1].Value);
        }

        [TestMethod]
        public void TestMethod8()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(4, board.Rows[0].cells[0].Value);
        }
        [TestMethod]
        public void TestMethod9()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(3, board.Rows[8].cells[8].Value);
        }

        [TestMethod]
        public void TestMethod10()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(8, board.Rows[3].cells[6].Value);
        }

        [TestMethod]
        public void TestMethod11()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(4, board.Columns[0].cells[0].Value);
        }

        [TestMethod]
        public void TestMethod12()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(1, board.Columns[2].cells[0].Value);
        }

        [TestMethod]
        public void TestMethod13()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(5, board.Columns[7].cells[2].Value);
        }
        [TestMethod]
        public void TestMethod14()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(7, board.Columns[4].cells[4].Value);
        }

        [TestMethod]
        public void TestMethod15()
        {
            SudokuBoard board = new SudokuBoard(data);
            board.Columns[4].cells[4].Value = 0;
            Assert.AreEqual(0, board.Rows[4].cells[4].Value);
        }

        [TestMethod]
        public void TestMethod16()
        {
            SudokuBoard board = new SudokuBoard(data);
            board.Columns[4].cells[4].Value = 0;
            Assert.AreEqual(0, board.Blocks[1, 1].cells[1, 1].Value);
        }

        [TestMethod]
        public void TestMethod17()
        {
            SudokuBoard board = new SudokuBoard(data);
            board.Rows[4].cells[4].Value = 0;
            Assert.AreEqual(0, board.Blocks[1, 1].cells[1, 1].Value);
        }

        [TestMethod]
        public void TestMethod18()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(true, board.Blocks[1, 1].ValidateNumbers());
        }
        [TestMethod]
        public void TestMethod19()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(true, board.Rows[5].ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod20()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(true, board.Columns[5].ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod21()
        {
            SudokuBoard board = new SudokuBoard(invalid);
            Assert.AreEqual(false, board.Blocks[1, 1].ValidateNumbers());
        }
        [TestMethod]
        public void TestMethod22()
        {
            SudokuBoard board = new SudokuBoard(invalid);
            Assert.AreEqual(false, board.Rows[4].ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod23()
        {
            SudokuBoard board = new SudokuBoard(invalid);
            Assert.AreEqual(false, board.Columns[4].ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod24()
        {
            SudokuBoard board = new SudokuBoard(invalid);
            Assert.AreEqual(false, board.ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod25()
        {
            SudokuBoard board = new SudokuBoard(data);
            Assert.AreEqual(true, board.ValidateNumbers());
        }

        [TestMethod]
        public void TestMethod26()
        {
            SudokuBoard board = new SudokuBoard(data);
            board[4, 4] = 0;
            Assert.AreEqual(0, board[4, 4]);
        }
    }


    [TestClass]
    public class UnitTestSudokuSolver
    {
        string dataJson = @"[
[0, 3, 1, 2, 5, 7, 6, 9, 8], 
[2, 5, 8, 6, 3, 9, 1, 7, 4], 
[6, 7, 9, 1, 4, 8, 3, 5, 2], 
[1, 2, 5, 4, 9, 6, 8, 3, 7], 
[8, 4, 6, 3, 0, 5, 2, 1, 9], 
[7, 9, 3, 8, 1, 2, 5, 4, 6], 
[3, 1, 2, 7, 6, 4, 9, 8, 5], 
[5, 6, 4, 9, 8, 3, 7, 2, 1], 
[9, 8, 7, 5, 2, 1, 4, 6, 0]]";



        string dataSlowJson = @"[
[0,0,4,9,0,7,0,0,0],
[0,2,0,3,0,0,0,8,9],
[7,0,0,1,0,0,0,0,6],
[0,0,0,0,0,8,0,0,0],
[0,5,0,0,7,0,1,0,8],
[8,9,7,6,1,0,0,0,2],
[3,4,8,5,6,0,0,7,1],
[0,6,0,7,0,4,0,0,0],
[9,7,2,0,3,0,5,6,0]]";

        //        string data2Json = @"[
        //[0, 3, 1, 0, 5, 0, 6, 0, 0], 
        //[0, 5, 0, 0, 3, 0, 1, 7, 4], 
        //[6, 0, 0, 1, 0, 0, 3, 0, 2], 
        //[1, 0, 5, 0, 0, 0, 0, 0, 7], 
        //[8, 0, "6", 0, 0, 0, 0, 0, 9], 
        //[0, 9, 0, 8, 0, 0, 5, 0, 0], 
        //[3, 1, 0, 0, 6, 0, 0, 8, 0], 
        //[0, 0, 0, 0, 0, 0, 0, 0, 0], 
        //[0, 8, 0, 0, 2, 0, 4, 0, 0]]";

        string data2Json = @"[
[0, 3, 1, 0, 5, 0, 6, 0, 0], 
[0, 5, 0, 0, 3, 0, 1, 7, 4], 
[6, 0, 0, 1, 0, 0, 3, 0, 2], 
[1, 0, 5, 0, 0, 0, 0, 0, 7], 
[8, 0, 0, 0, 0, 0, 0, 0, 9], 
[0, 9, 0, 8, 0, 0, 5, 0, 0], 
[3, 1, 0, 0, 6, 0, 0, 8, 0], 
[0, 0, 0, 0, 0, 0, 0, 0, 0], 
[0, 8, 0, 0, 2, 0, 4, 0, 0]]";


        int[,] data = null;
        int[,] data2 = null;


        public UnitTestSudokuSolver()
        {
            data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            data2 = JsonConvert.DeserializeObject<int[,]>(data2Json);
        }

        [TestMethod]
        public void TestMethod1()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.GetEmptyCells(board);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void TestMethod2()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            StrategyRow stgRow = new StrategyRow();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 0 && c.absY == 0).FirstOrDefault();
            stgRow.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[4]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            StrategyColumn stgclm = new StrategyColumn();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgclm.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[3]);
        }


        [TestMethod]
        public void TestMethod4()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            StrategyRow stgRow = new StrategyRow();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgRow.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[3]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            StrategyBlock stgBlk = new StrategyBlock();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgBlk.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[3]);
        }

        //[TestMethod]
        //public void TestMethod6()
        //{
        //    SudokuBoard board = new SudokuBoard(data);
        //    SudokuSolver solver = new SudokuSolver();
        //    var pvc = solver.EvaluatePossibleValuesInCell(board, solver.GetEmptyCells(board).Where(c => c.absX == 4 && c.absY == 4).FirstOrDefault());
        //    Assert.AreEqual(5, pvc.possibleValues[7]);
        //}


        [TestMethod]
        public void TestMethod7()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var emptyCells = solver.GetEmptyCells(board);
            var result = solver.MakeCellValueWithProbability(board, emptyCells);
            Assert.AreEqual(7, result.Where(r => r.cell.absX == 4 && r.cell.absY == 4).FirstOrDefault().value);
        }

        [TestMethod]
        public void TestMethod8()
        {
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var emptyCells = solver.GetEmptyCells(board);
            var result = solver.MakeCellValueWithProbability(board, emptyCells);
            Assert.AreEqual(1.0, result.Where(r => r.cell.absX == 4 && r.cell.absY == 4).FirstOrDefault().probability);
        }

        [TestMethod]
        public void TestMethod9()
        {
            SudokuBoard board = new SudokuBoard(data2);
            SudokuSolver solver = new SudokuSolver();
            var emptyCells1 = solver.GetEmptyCells(board);
            var result1 = solver.MakeCellValueWithProbability(board, emptyCells1).OrderByDescending(c => c.probability);

            var trialCell = result1.FirstOrDefault();
            int trialValue = trialCell.value;
            trialCell.cell.Value = trialValue;
            //////////////////////
            var emptyCells2 = solver.GetEmptyCells(board);
            var result2 = solver.MakeCellValueWithProbability(board, emptyCells2).OrderByDescending(c => c.probability);
            //////////////////////////////////////
            trialCell.cell.Value = 0;
            var emptyCells3 = solver.GetEmptyCells(board);
            var result3 = solver.MakeCellValueWithProbability(board, emptyCells3).OrderByDescending(c => c.probability);
            ////////////////
            Assert.AreEqual(result1.Count(), result3.Count());
            Assert.AreEqual(result1.Last().probability, result3.Last().probability);
            Assert.AreEqual(result1.Last().value, result3.Last().value);
            Assert.AreEqual(result1.First().value, result3.First().value);
        }

        [TestMethod]
        public void TestMethod10()
        {
            SudokuBoard board = new SudokuBoard(data2);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestMethod11()
        {
            string testJson = @"[
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,3,0,0,0,0],
[0,3,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0]
]";
            int[,] test = JsonConvert.DeserializeObject<int[,]>(testJson);
            SudokuBoard board = new SudokuBoard(test);
            SudokuSolver solver = new SudokuSolver();
            StrategyOtherRows stgOrs = new StrategyOtherRows();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgOrs.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[3]);
        }
        [TestMethod]
        public void TestMethod11a()
        {
            string testJson = @"[
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,3,0,0,0,0],
[0,3,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,2,0]
]";
            int[,] test = JsonConvert.DeserializeObject<int[,]>(testJson);
            SudokuBoard board = new SudokuBoard(test);
            SudokuSolver solver = new SudokuSolver();
            StrategyOtherRows stgOrs = new StrategyOtherRows();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgOrs.Evaluate(board, pvc);
            Assert.AreEqual(2, pvc.possibleValues[3]);
        }

        [TestMethod]
        public void TestMethod12()
        {
            string testJson = @"[
[0,0,0,0,0,0,3,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,3,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0]
]";
            int[,] test = JsonConvert.DeserializeObject<int[,]>(testJson);
            SudokuBoard board = new SudokuBoard(test);
            SudokuSolver solver = new SudokuSolver();
            StrategyOtherColumns stgOcs = new StrategyOtherColumns();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgOcs.Evaluate(board, pvc);
            Assert.AreEqual(1, pvc.possibleValues[3]);
        }

        [TestMethod]
        public void TestMethod12a()
        {
            string testJson = @"[
[0,0,0,0,0,0,3,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,3,0],
[0,0,0,0,0,0,0,0,2],
[0,0,0,0,0,0,0,0,1],
[0,0,0,0,0,0,0,0,0]
]";
            int[,] test = JsonConvert.DeserializeObject<int[,]>(testJson);
            SudokuBoard board = new SudokuBoard(test);
            SudokuSolver solver = new SudokuSolver();
            StrategyOtherColumns stgOcs = new StrategyOtherColumns();
            var result = solver.GetEmptyCells(board);
            var pvc = result.Where(c => c.absX == 8 && c.absY == 8).FirstOrDefault();
            stgOcs.Evaluate(board, pvc);
            Assert.AreEqual(2, pvc.possibleValues[3]);
        }

    }

    [TestClass]
    public class UnitTestSudokuQuestions
    {
        [TestMethod]
        public void TestMethod1()
        {
            string Q1dataJson = @"[
[0,0,0,0,0,0,1,0,0],
[1,0,0,0,0,6,0,8,9],
[6,7,0,0,0,8,2,0,5],
[0,1,2,0,0,9,0,7,8],
[4,5,0,7,0,1,3,0,0],
[0,9,0,0,6,0,0,0,0],
[5,2,1,8,7,4,0,3,6],
[0,0,0,9,0,5,0,0,0],
[9,8,0,6,0,3,0,0,0]]";
            int[,] Q1data = JsonConvert.DeserializeObject<int[,]>(Q1dataJson);
            SudokuBoard board = new SudokuBoard(Q1data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
            //helper.SaveToTxt(board, "Q1.txt");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string dataJson = @"[[2,3,0,0,0,4,0,0,0],[0,0,0,2,0,0,3,0,0],[7,8,9,0,0,6,0,0,0],[3,1,2,4,0,5,7,0,0],[0,5,7,0,0,8,2,3,0],[6,0,0,0,0,0,0,0,1],[0,0,0,6,0,0,8,9,3],[0,6,4,9,3,0,5,1,7],[9,0,3,5,0,0,0,0,2]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string dataJson = @"[[0,0,0,0,0,0,2,0,0],[0,0,5,1,4,0,7,0,9],[6,0,9,2,0,8,0,0,0],[0,2,0,4,6,0,0,9,0],[0,5,0,0,0,0,0,1,0],[7,0,0,0,0,0,4,0,6],[0,4,0,5,9,0,6,0,0],[5,0,2,0,3,0,9,7,1],[9,8,7,6,2,0,5,0,3]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string dataJson = @"[[0,0,0,0,2,0,0,0,8],[0,2,0,4,6,8,0,0,0],[0,5,8,0,7,0,1,0,0],[2,0,4,6,0,0,8,9,0],[3,0,0,8,9,0,0,0,1],[8,9,6,0,4,7,0,3,0],[5,0,0,0,1,6,0,0,4],[6,0,0,0,0,0,0,5,2],[9,0,0,0,5,4,6,1,0]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string dataJson = @"[[0,0,1,0,2,5,0,0,0],[0,0,0,6,0,0,0,0,0],[6,0,9,0,0,7,0,0,0],[1,2,3,0,0,0,0,0,9],[0,0,0,0,0,0,0,0,0],[0,0,7,0,0,0,0,6,0],[3,0,2,5,6,0,9,0,8],[5,6,0,9,7,0,0,0,0],[9,7,4,0,0,2,6,0,1]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        //[TestMethod]
        //public void TestMethod6()
        //{
        //    string dataJson = @"[[0,0,0,0,0,0,0,0,0],[0,2,0,0,0,6,0,0,0],[4,5,0,0,0,0,0,0,6],[0,0,0,0,3,7,0,0,0],[0,0,0,0,0,0,0,4,7],[8,0,7,6,0,0,3,0,0],[5,3,8,7,0,2,9,0,0],[6,4,2,0,1,0,0,7,0],[9,7,0,8,0,0,0,5,0]]";
        //    int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
        //    SudokuBoard board = new SudokuBoard(data);
        //    SudokuSolver solver = new SudokuSolver();
        //    var result = solver.BestFirstSearch(board);
        //    Assert.AreEqual(true, result);
        //}

        [TestMethod]
        public void TestMethod7()
        {
            string dataJson = @"[[0,8,0,0,4,0,9,1,0],[0,2,0,3,5,0,0,7,8],[5,7,0,0,0,0,0,0,0],[0,1,0,0,7,5,0,6,0],[0,5,0,6,0,0,3,0,7],[0,0,7,0,0,3,4,0,1],[7,3,1,9,8,0,5,0,0],[0,0,0,0,0,0,0,0,0],[0,6,0,0,0,0,0,8,2]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string dataJson = @"[[0,0,0,0,0,0,0,9,0],[0,0,4,0,6,0,5,0,0],[0,0,0,0,0,8,1,0,0],[3,0,0,4,0,0,0,0,0],[4,0,7,8,9,1,0,0,0],[8,0,0,0,0,3,0,0,5],[0,0,0,0,8,0,0,0,0],[0,0,0,9,0,2,6,0,0],[0,0,3,6,1,7,0,5,0]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        //[TestMethod]
        //public void TestMethod9()
        //{
        //    string dataJson = @"[[0,0,0,0,0,5,0,3,8],[0,0,3,0,6,0,0,0,0],[5,0,0,0,3,0,0,4,0],[0,1,0,3,0,6,0,0,0],[3,0,0,0,0,0,0,1,0],[0,9,0,0,0,0,3,0,0],[0,0,0,6,7,0,9,0,0],[8,0,0,0,0,0,0,0,0],[0,7,0,8,4,0,0,5,3]]";
        //    int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
        //    SudokuBoard board = new SudokuBoard(data);
        //    SudokuSolver solver = new SudokuSolver();
        //    var result = solver.BestFirstSearch(board);
        //    Assert.AreEqual(true, result);
        //}

        [TestMethod]
        public void TestMethod10()
        {
            string dataJson = @"[[0,0,0,0,2,9,0,0,0],[0,2,0,0,0,6,7,0,0],[0,7,0,0,0,0,0,0,0],[2,0,0,0,0,0,8,0,0],[0,0,0,8,9,0,1,0,0],[0,9,7,0,0,0,0,0,0],[0,0,0,0,7,0,9,0,8],[0,8,0,0,3,0,0,1,6],[0,6,4,0,8,0,3,0,2]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void TestMethod12()
        {
            string dataJson = @"[[0,0,4,0,0,0,0,0,0],[0,0,0,3,0,0,4,0,9],[6,0,0,0,4,0,2,0,5],[0,0,3,0,5,0,7,9,0],[0,5,0,7,0,0,0,2,3],[0,9,0,0,0,0,0,0,6],[0,4,0,8,0,0,9,6,7],[0,0,7,9,0,0,0,1,0],[0,8,0,0,7,0,3,0,4]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod13()
        {
            string dataJson = @"[[0,0,0,0,7,1,8,0,0],[0,0,0,0,6,0,0,0,0],[0,0,0,0,0,0,1,2,0],[2,1,0,0,0,0,0,0,0],[0,6,0,0,9,0,0,0,0],[0,9,7,0,0,0,4,0,6],[0,0,0,0,8,2,0,4,0],[7,0,6,9,1,5,3,0,0],[9,8,2,7,3,4,6,1,0]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod14()
        {
            string dataJson = @"[[0,0,0,0,0,0,4,0,0],[0,0,0,0,5,0,0,0,9],[0,7,0,3,0,0,0,0,0],[1,0,0,0,0,0,0,9,7],[4,5,7,2,9,0,3,6,0],[0,8,0,0,0,3,0,5,4],[3,0,5,6,0,1,0,0,8],[7,0,0,0,8,0,5,0,3],[0,0,1,5,3,7,6,0,2]]";
            int[,] data = JsonConvert.DeserializeObject<int[,]>(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            var result = solver.BestFirstSearch(board);
            Assert.AreEqual(true, result);
        }


    }
}
