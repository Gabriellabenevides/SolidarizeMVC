using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidarizeMVC.Data;
using SolidarizeMVC.Models;

namespace SolidarizeMVC.Controllers
{
    public class DoacaoController : Controller
    {
        readonly private ApplicationDbContext _db;
        public DoacaoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<DoacaoModel> doacoes = _db.Doacoes
                .Include(d => d.Campanha)  
                .Include(d => d.Doador)    
                .ToList();

            return View(doacoes);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
