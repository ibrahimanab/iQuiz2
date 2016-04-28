using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class RulesController : Controller
    {
        private ApplicationDbContext _context;

        public RulesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Rules
        public IActionResult Index()
        {
            return View(_context.Rules.ToList());
        }

        // GET: Rules/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Rules rules = _context.Rules.Single(m => m.RulesID == id);
            if (rules == null)
            {
                return HttpNotFound();
            }

            return View(rules);
        }

        // GET: Rules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Rules/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Rules rules = _context.Rules.Single(m => m.RulesID == id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // POST: Rules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rules rules)
        {
            if (ModelState.IsValid)
            {
                _context.Update(rules);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rules);
        }

        // GET: Rules/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Rules rules = _context.Rules.Single(m => m.RulesID == id);
            if (rules == null)
            {
                return HttpNotFound();
            }

            return View(rules);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Rules rules = _context.Rules.Single(m => m.RulesID == id);
            _context.Rules.Remove(rules);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
