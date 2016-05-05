using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using GeekQuiz.Models;
using Microsoft.AspNet.Http.Internal;

namespace GeekQuiz.Controllers
{
   

    [Authorize]
  

    public class HomeController : Controller
    {

       
        private TriviaDbContext context;

        public HomeController(TriviaDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Rules(Rooms model)
        {

            context.Rooms.Add(model);
            await this.context.SaveChangesAsync();
            return View("Startgame");
        }

        //called from angular http object
        public Rooms gettime()
        {

            var rule= new Rooms();
            rule.timeperquestion = 30;
            return rule;
               //return context.Rules.Where(a => a.timeperquestion == 30).First();
        }




    

       

        public IActionResult Index()
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
