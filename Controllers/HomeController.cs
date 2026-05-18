using System.Diagnostics;
//using Bilet_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bilet_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

         
    }
}
