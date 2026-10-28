using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using taskManger.Models;

namespace taskManger.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskmanagemntContext _context;
        public HomeController(TaskmanagemntContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            var user =_context.Usres.ToList();
        
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Usre = new SelectList(_context.Usres);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usre user)
        {
            if (ModelState.IsValid)
            {
                _context.Usres.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var usre = _context.Usres.Find(id);
            if(usre != null)
            {
                _context.Remove(usre);
                _context.SaveChanges();
                
            }
            return RedirectToAction("Index");
            //return View(usre);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
