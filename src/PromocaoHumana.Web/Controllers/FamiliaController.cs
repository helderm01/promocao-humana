using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromocaoHumana.Web.Data;
using PromocaoHumana.Web.Domain;
using PromocaoHumana.Web.Infra;
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

        public IActionResult Edit(int id)
        {
            var familia = _db.Familias.Find(id);

            return View(new FamiliaViewModel
            {
                Id = familia.Id,
                Ativa = familia.Ativa,
                Bairro = familia.Bairro,
                Cep = familia.Cep,
                Cidade = familia.Cidade,
                Complemento = familia.Complemento,
                Logradouro = familia.Logradouro,
                Numero = familia.Numero,
                Observacoes = familia.Observacoes,
                Telefone = familia.Telefone,
                Uf = familia.Uf,
                CpfResponsavel = familia.CpfResponsavel,
                DataCadastro = familia.DataCadastro,
                NomeConjuge = familia.NomeConjuge,
                NomeResponsavel = familia.NomeResponsavel,
                QuantidadeFilhos = familia.QuantidadeFilhos
            });
        }

        public IActionResult Delete(int id)
        {
            var familia = _db.Familias.Find(id);

            _db.Familias.Remove(familia);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Salvar(FamiliaViewModel familiaViewModel)
        {
            if (!ModelState.IsValid)
                return View("_Familia", familiaViewModel);

            try
            {
                if (familiaViewModel.Id == 0)
                {
                    var familia = new Familia(familiaViewModel.NomeResponsavel, familiaViewModel.CpfResponsavel);
                    familia.AtribuirBairro(familiaViewModel.Bairro);
                    familia.AtribuirCep(familiaViewModel.Cep);
                    familia.AtribuirCidade(familiaViewModel.Cidade);
                    familia.AtribuirComplemento(familiaViewModel.Complemento);
                    familia.AtribuirConjuge(familiaViewModel.NomeConjuge);
                    familia.AtribuirLogradouro(familiaViewModel.Logradouro);
                    familia.AtribuirNumero(familiaViewModel.Numero);
                    familia.AtribuirObservacao(familiaViewModel.Observacoes);
                    familia.AtribuirTelefone(familiaViewModel.Telefone);
                    familia.AtribuirUf(familiaViewModel.Uf);
                    familia.AtribuirQuantidadeDeFilhos(familiaViewModel.QuantidadeFilhos);

                    _db.Familias.Add(familia);
                    _db.SaveChanges();
                }
                else
                {
                    var familia = _db.Familias.Find(familiaViewModel.Id);
                    familia.AtribuirBairro(familiaViewModel.Bairro);
                    familia.AtribuirCep(familiaViewModel.Cep);
                    familia.AtribuirCidade(familiaViewModel.Cidade);
                    familia.AtribuirComplemento(familiaViewModel.Complemento);
                    familia.AtribuirConjuge(familiaViewModel.NomeConjuge);
                    familia.AtribuirLogradouro(familiaViewModel.Logradouro);
                    familia.AtribuirNumero(familiaViewModel.Numero);
                    familia.AtribuirObservacao(familiaViewModel.Observacoes);
                    familia.AtribuirTelefone(familiaViewModel.Telefone);
                    familia.AtribuirUf(familiaViewModel.Uf);
                    familia.AtribuirQuantidadeDeFilhos(familiaViewModel.QuantidadeFilhos);
                    familia.AtribuirResponsavel(familiaViewModel.NomeResponsavel);
                    familia.AtribuirCpfResponsavel(familiaViewModel.CpfResponsavel);

                    _db.Familias.Update(familia);
                    _db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Familia", familiaViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ConsultaCep(string cep, FamiliaViewModel viewModel)
        {
            var viaCep = new ServicoViaCep();
            var endereco = viaCep.ObterEndereco(viewModel.Cep);

            if (endereco != null)
            {
                viewModel.Cep = endereco.Cep;
                viewModel.Uf = endereco.Uf;
                viewModel.Cidade = endereco.Localidade;
                viewModel.Bairro = endereco.Bairro;
                viewModel.Logradouro = endereco.Logradouro;
            }
            else
            {
                ViewBag.ErrorMessage = "CEP não encontrado.";
                return View("_Familia", viewModel);
            }

            return View("_Familia", viewModel);
        }
    }
}