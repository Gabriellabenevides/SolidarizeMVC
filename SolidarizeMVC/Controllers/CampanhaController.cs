using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidarizeMVC.Data;
using SolidarizeMVC.Models;

namespace SolidarizeMVC.Controllers
{
    public class CampanhaController : Controller
    {
        readonly private ApplicationDbContext _db;
        public CampanhaController(ApplicationDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<CampanhaModel> campanhas = _db.Campanhas
                .Include(c => c.Doacoes) 
                .ToList();

            return View(campanhas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Cadastrar(CampanhaModel campanhas)
        {
            if (ModelState.IsValid)
            {
                _db.Campanhas.Add(campanhas);
                _db.SaveChanges();

                return RedirectToAction("Index");
            } 
            return View();
        }
    }
}
