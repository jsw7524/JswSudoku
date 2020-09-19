using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sudoku;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
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

        int[,] data = null;

        public UnitTest1()
        {
            data = JsonConvert.DeserializeObject<int[,]>(dataJson);
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
    }
}
