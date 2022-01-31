using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Domain;
using PromocaoHumana.Web.Models.Igreja;

namespace PromocaoHumana.Web.Controllers
{
    [Authorize]
    public class IgrejaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IgrejaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var igrejas = _db.Igrejas.ToList();
            var retorno = igrejas.Select(c => new IgrejaViewModel()
            {
                Id = c.Id,
                Nome = c.Nome,
                Cnpj = c.Cnpj
            });

            return View(retorno);
        }

        public IActionResult Edit(int id)
        {
            var igreja = _db.Igrejas.Find(id);

            return View(new IgrejaViewModel
            {
                Id = igreja.Id,
                Cnpj = igreja.Cnpj,
                Nome = igreja.Nome
            });
        }

        public IActionResult Create()
        {
            return View(new IgrejaViewModel());
        }

        public IActionResult Salvar(IgrejaViewModel igrejaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("_Igreja", igrejaViewModel);
            }
            
            try
            {
                if (igrejaViewModel.Id == 0)
                {
                    var novaIgreja = new Igreja(igrejaViewModel);
                    _db.Igrejas.Add(novaIgreja);
                    _db.SaveChanges();
                }
                else
                {
                    var igreja = _db.Igrejas.Find(igrejaViewModel.Id);
                    igreja.AtribuirNome(igrejaViewModel.Nome);
                    igreja.AtribuirCnpj(igrejaViewModel.Cnpj);
            
                    _db.Igrejas.Update(igreja);
                    _db.SaveChanges();
                }
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException?.Message.Contains("IX_Igreja_Cnpj") ?? false)
                {
                    ModelState.AddModelError("Cnpj", "CNPJ já existe para outro registro.");
                }
                else
                {
                    ViewBag.ErrorMessage = e.Message;
                }

                return View("_Igreja", igrejaViewModel);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var igreja = _db.Igrejas.Find(id);
            
            _db.Igrejas.Remove(igreja);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}