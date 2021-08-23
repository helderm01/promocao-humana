using System;
using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        // [HttpPost]
        public IActionResult Create()
        {
            // var novaIgreja = new Igreja(igrejaViewModel);
            // _db.Igrejas.Add(novaIgreja);
            // _db.SaveChanges();
            //
            // return RedirectToAction("Index");
            return View(new NovaIgrejaViewModel());
        }

        // public IActionResult Post(IgrejaViewModel igrejaViewModel)
        // {
        //     if (igrejaViewModel.Id == 0)
        //     {
        //         var novaIgreja = new Igreja(igrejaViewModel);
        //         _db.Igrejas.Add(novaIgreja);
        //         _db.SaveChanges();
        //     }
        //     else
        //     {
        //         throw new NotImplementedException();
        //     }
        //     
        //     return 
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}