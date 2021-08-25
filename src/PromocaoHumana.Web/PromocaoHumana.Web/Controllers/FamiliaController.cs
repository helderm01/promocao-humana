using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Models.Familia;

namespace PromocaoHumana.Web.Controllers
{
    [Authorize]
    public class FamiliaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FamiliaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var familias = _db.Familias.ToList();
            var retorno = familias.Select(c => new FamiliaViewModel()
            {
                Id = c.Id,
                NomeResponsavel = c.NomeResponsavel,
                CpfResponsavel = c.CpfResponsavel,
                NomeConjuge = c.NomeConjuge,
                QuantidadeFilhos = c.QuantidadeFilhos
            });

            return View(retorno);
        }

        public IActionResult Create()
        {
            return View(new FamiliaViewModel());
        }

        public IActionResult Salvar(FamiliaViewModel familiaViewModel)
        {
            throw new NotImplementedException();
        }
    }
}