using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _service;
        public ExpensesController(IExpensesService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAll();

            return View(expenses);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            else 
            {
               await _service.Add(expense);

                return RedirectToAction("Index");
            }
        }
    }
}
