using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Models.Doacao;

namespace PromocaoHumana.Web.Controllers
{
    [Authorize]
    public class DoacaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DoacaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var doacoes = _db.Doacoes.ToList();
            var retorno = doacoes.Select(c => new DoacaoViewModel
            {
                Id = c.Id,
                Descricao = c.Descricao,
                FamiliaId = c.FamiliaId,
                LocalRetirada = c.LocalRetirada.Nome,
                MesRetirada = c.MesRetirada,
                QuemRetirou = c.QuemRetirou,
                ResponsavelFamilia = c.Familia.NomeResponsavel,
                LocalRetiradaId = c.LocalRetiradaId
            });

            return View(retorno);
        }

        // public IActionResult Create()
        // {
        //     return View(new DoacaoViewModel());
        // }
    }
}