using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidarizeMVC.Data;
using SolidarizeMVC.Models;

namespace SolidarizeMVC.Controllers
{
    public class DoadorController : Controller
    {
        readonly private ApplicationDbContext _db;
        public DoadorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<DoadorModel> doadores = _db.Doadores
                .Include(d => d.Doacoes)
                .ThenInclude(doacao => doacao.Campanha) 
                .ToList();

            return View(doadores);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
