using Bilet_1.Dal;
using Bilet_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bilet_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

   
        public IActionResult Index()
        {
            var data = _context.Members
                .Include(x => x.Employee)
                .ToList();

            return View(data);
        }

      
        public IActionResult Create()
        {
            ViewBag.Employees =
                new SelectList(_context.Employees, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees =
                    new SelectList(_context.Employees, "Id", "Name");

                return View(member);
            }

            _context.Members.Add(member);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var data = _context.Members
                .FirstOrDefault(x => x.Id == id);

            ViewBag.Employees =
                new SelectList(_context.Employees, "Id", "Name");

            return View(data);
        }


        [HttpPost]
        public IActionResult Update(Member member)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees =
                    new SelectList(_context.Employees, "Id", "Name");

                return View(member);
            }

            _context.Members.Update(member);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
      
        public IActionResult Delete(int id)
        {
            var data = _context.Members
                .FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                _context.Members.Remove(data);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}