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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DoacaoModel doacao = _db.Doacoes.FirstOrDefault(x => x.Id == id);

            if (doacao == null)
            {
                return NotFound();
            }

            return View(doacao);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DoacaoModel doacao = _db.Doacoes.FirstOrDefault(x => x.Id == id);

            if (doacao == null)
            {
                return NotFound();
            }
            return View(doacao);
        }

        [HttpPost]
        public IActionResult Cadastrar(DoacaoModel doacoes)
        {
            if (ModelState.IsValid)
            {
                _db.Doacoes.Add(doacoes);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar o cadastro!";

            return View();
        }

        [HttpPost]
        public IActionResult Editar(DoacaoModel doacao)
        {
            if (ModelState.IsValid)
            {
                _db.Doacoes.Update(doacao);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro editado com sucesso!";

                return RedirectToAction("Index");
            }
            return View(doacao);
        }

        [HttpPost]
        public IActionResult Excluir(DoacaoModel doacao)
        {
            if (doacao == null)
            {
                return NotFound();
            }

            _db.Doacoes.Remove(doacao);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Cadastro excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
