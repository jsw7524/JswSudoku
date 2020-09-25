using Newtonsoft.Json;
using Sudoku;
using SudokuUI.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SudokuUI.Controllers
{
    public class SudokuController : Controller
    {
        public ActionResult GetSudokuBoardData()
        {
            string json = null;
            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync(new Uri("https://sugoku.herokuapp.com/board?difficulty=easy"));
                responseTask.Wait();
                var result = responseTask.Result;

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();


                json = readTask.Result;
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        int[,] DicToIntArray(Dictionary<string, object> dataJson)
        {
            var tmp = dataJson.Select(r => r.Value as string[]).ToList();
            int[,] result = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (tmp[i][j] == "")
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        result[i, j] = int.Parse(tmp[i][j]);
                    }
                }
            }
            return result;

        }

        [HttpPost]
        public ActionResult sovleSudoku(Dictionary<string, object> dataJson)
        {
            int[,] data = DicToIntArray(dataJson);
            SudokuBoard board = new SudokuBoard(data);
            SudokuSolver solver = new SudokuSolver();
            solver.BestFirstSearch(board);
            var result = helper.GetBoardJson(board);

            return Json(result);
        }

        // GET: Sudoku
        public ActionResult Index()
        {
            SudokuViewModel viewModel = new SudokuViewModel();

            return View(viewModel);
        }
    }
}