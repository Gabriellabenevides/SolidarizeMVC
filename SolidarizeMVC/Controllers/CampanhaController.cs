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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CampanhaModel campanha = _db.Campanhas.FirstOrDefault(x => x.Id == id);

            if (campanha == null)
            {
                return NotFound();
            }
            return View(campanha);
        }

        [HttpPost]
        public IActionResult Cadastrar(CampanhaModel campanhas)
        {
            if (ModelState.IsValid)
            {
                _db.Campanhas.Add(campanhas);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar o cadastro!";

            return View();
        }

        [HttpPost]
        public IActionResult Editar(CampanhaModel campanha)
        {
            if (ModelState.IsValid)
            {
                _db.Campanhas.Update(campanha);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro editado com sucesso!";

                return RedirectToAction("Index");
            }
            return View(campanha);
        }
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CampanhaModel campanha = _db.Campanhas.FirstOrDefault(x => x.Id == id);

            if (campanha == null)
            {
                return NotFound();
            }
            return View(campanha);
        }

        [HttpPost]
        public IActionResult Excluir(CampanhaModel campanha)
        {
            if(campanha == null)
            {
                return NotFound();
            }

            TempData["MensagemSucesso"] = "Cadastro excluido com sucesso!";

            _db.Campanhas.Remove(campanha);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
