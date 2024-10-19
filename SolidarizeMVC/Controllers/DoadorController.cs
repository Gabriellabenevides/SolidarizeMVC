using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolidarizeMVC.Data;
using SolidarizeMVC.Models;

namespace SolidarizeMVC.Controllers
{
    public class DoadorController : Controller
    {
        private readonly ApplicationDbContext _db;

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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DoadorModel doador = _db.Doadores.FirstOrDefault(x => x.Id == id);

            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DoadorModel doador = _db.Doadores.FirstOrDefault(x => x.Id == id);

            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        [HttpPost]
        public IActionResult Cadastrar(DoadorModel doadores)
        {
            if (ModelState.IsValid)
            {
                _db.Doadores.Add(doadores);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar o cadastro!";

            return View();
        }

        [HttpPost]
        public IActionResult Editar(DoadorModel doador)
        {
            if (ModelState.IsValid)
            {
                _db.Doadores.Update(doador);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro editado com sucesso!";


                return RedirectToAction("Index");
            }
            return View(doador);
        }

        [HttpPost]
        public IActionResult Excluir(DoadorModel doador)
        {
            if (doador == null)
            {
                return NotFound();
            }

            _db.Doadores.Remove(doador);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Cadastro excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
