using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var doacoes = _db.Doacoes.ToList();
            var retorno = doacoes.Select(c => new DoacaoViewModel
            {
                Id = c.Id,
                Descricao = c.Descricao,
                FamiliaId = c.FamiliaId,
                LocalRetirada = c.LocalRetirada.Nome,
                MesRetirada = c.MesRetirada,
                QuemRetirou = c.QuemRetirou,
                Familia = c.Familia.NomeResponsavel,
                LocalRetiradaId = c.LocalRetiradaId
            });

            return View(retorno);
        }

        public IActionResult Create()
        {
            return View(new DoacaoViewModel());
        }

        public IActionResult Edit(int id)
        {
            var doacao = _db.Doacoes.Find(id);

            return View(new DoacaoViewModel
            {
                Id = doacao.Id,
                Descricao = doacao.Descricao,
                FamiliaId = doacao.FamiliaId,
                LocalRetirada = doacao.LocalRetirada.Nome,
                MesRetirada = doacao.MesRetirada,
                QuemRetirou = doacao.QuemRetirou,
                Familia = doacao.Familia.NomeResponsavel,
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
                var localRetirada = _db.Igrejas.Find(doacaoViewModel.FamiliaId);

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
                ViewBag.ErrorMessage = e.Message;
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
    }
}