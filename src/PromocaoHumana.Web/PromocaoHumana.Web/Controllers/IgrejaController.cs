using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Models.Igreja;

namespace PromocaoHumana.Web.Controllers
{
    [Authorize]
    public class IgrejaController: Controller
    {
        private readonly ApplicationDbContext _db;

        public IgrejaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}