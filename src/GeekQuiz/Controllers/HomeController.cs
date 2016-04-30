using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
   

    [Authorize]
  

    public class HomeController : Controller
    {

        private RulesDbContext _context;

        public HomeController(RulesDbContext context) { _context = context; }




        [HttpPost]
        public ActionResult Index(string Answer)
        {
            var x = Answer;

            return View("Startgame");
        }



        [HttpPost]
        public IActionResult Create(Rules rules)
        {
            if (ModelState.IsValid)
            {
                _context.Rules.Add(rules);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rules);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Startgame()
        {
          
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Rules()
        {
            return View();
        }

    }
}
