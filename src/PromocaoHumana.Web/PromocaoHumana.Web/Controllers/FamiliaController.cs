using System;
using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Models.Familia;

namespace PromocaoHumana.Web.Controllers
{
    public class FamiliaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salvar(FamiliaViewModel familiaViewModel)
        {
            throw new NotImplementedException();
        }
    }
}