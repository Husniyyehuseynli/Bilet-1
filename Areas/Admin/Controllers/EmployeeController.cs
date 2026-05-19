using Bilet_1.Dal;
using Bilet_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
                return View(emp);

            _context.Employees.Add(emp);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = _context.Employees
                .FirstOrDefault(x => x.Id == id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            if (!ModelState.IsValid)
                return View(emp);

            _context.Employees.Update(emp);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _context.Employees
                .FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                _context.Employees.Remove(data);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}