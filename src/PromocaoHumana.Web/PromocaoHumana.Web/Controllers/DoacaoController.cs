using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Domain;
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
            var doacoes = _db.Doacoes
                .Include(c => c.Familia)
                .Include(c=>c.LocalRetirada)
                .ToList();
            
            var retorno = doacoes.Select(c => new DoacaoViewModel
            {
                Id = c.Id,
                Descricao = c.Descricao,
                FamiliaId = c.FamiliaId,
                LocalRetirada = c.LocalRetirada?.Nome,
                MesRetirada = c.MesRetirada,
                QuemRetirou = c.QuemRetirou,
                Familia = c.Familia?.NomeResponsavel,
                LocalRetiradaId = c.LocalRetiradaId
            });

            return View(retorno);
        }

        public IActionResult Create()
        {
            CarregarDropDowns();

            return View(new DoacaoViewModel());
        }

        public IActionResult Edit(int id)
        {
            CarregarDropDowns();

            var doacao = _db.Doacoes.Find(id);

            return View(new DoacaoViewModel
            {
                Id = doacao.Id,
                Descricao = doacao.Descricao,
                FamiliaId = doacao.FamiliaId,
                MesRetirada = doacao.MesRetirada,
                QuemRetirou = doacao.QuemRetirou,
                LocalRetiradaId = doacao.LocalRetiradaId
            });
        }

        public IActionResult Salvar(DoacaoViewModel doacaoViewModel)
        {
            if (!ModelState.IsValid)
                return View("_Doacao", doacaoViewModel);

            try
            {
                var familia = _db.Familias.Find(doacaoViewModel.FamiliaId);
                var localRetirada = _db.Igrejas.Find(doacaoViewModel.LocalRetiradaId);

                if (doacaoViewModel.Id == 0)
                {
                    var doacao = new Doacao(familia, localRetirada, doacaoViewModel.QuemRetirou);
                    doacao.AtribuirDescricao(doacaoViewModel.Descricao);

                    _db.Doacoes.Add(doacao);
                    _db.SaveChanges();
                }
                else
                {
                    var doacao = _db.Doacoes.Find(doacaoViewModel.Id);
                    doacao.AtribuirDescricao(doacaoViewModel.Descricao);
                    doacao.AtribuirLocalRetirada(localRetirada);
                    doacao.AtribuirQuemRetirou(doacaoViewModel.QuemRetirou);
                    doacao.AtribuirFamilia(familia);

                    _db.Doacoes.Update(doacao);
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                if (e.InnerException?.Message.Contains("IX_Doacao_MesRetirada_FamiliaId") ?? false)
                {
                    ModelState.AddModelError("FamiliaId", "Família informada já recebeu doação esse mês.");
                }
                else
                {
                    ViewBag.ErrorMessage = e.Message;
                }
                
                return View("_Doacao", doacaoViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var doacao = _db.Doacoes.Find(id);

            _db.Doacoes.Remove(doacao);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        private void CarregarDropDowns()
        {
            var familias = _db.Familias.Select(c => new
            {
                Id = c.Id,
                Nome = c.NomeResponsavel
            }).ToList();
            familias.Add(new {Id = 0, Nome = ""});

            ViewData["Familias"] = new SelectList
            (
                familias,
                "Id",
                "Nome",
                0
            );

            var igrejas = _db.Igrejas.Select(c => new
            {
                Id = c.Id,
                Nome = c.Nome
            }).ToList();
            igrejas.Add(new {Id = 0, Nome = ""});

            ViewData["Igrejas"] = new SelectList
            (
                igrejas,
                "Id",
                "Nome",
                0
            );
        }
    }
}