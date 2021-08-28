using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PromocaoHumana.Web.Domain.Structs;

namespace PromocaoHumana.Web.Domain
{
    public class Familia : EntidadeBase
    {
        public DateTime DataCadastro { get; private set; } = DateTime.Today;
        public bool Ativa { get; private set; } = true;
        public string NomeResponsavel { get; private set; }
        public Cpf CpfResponsavel { get; private set; }
        public string NomeConjuge { get; private set; }
        public int QuantidadeFilhos { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Telefone { get; private set; }
        public string Observacoes { get; private set; }
        public ICollection<Doacao> Doacoes { get; set; }

        protected Familia()
        {
        }

        public Familia(string nomeResponsavel, string cpfResponsavel)
        {
            AtribuirResponsavel(nomeResponsavel);

            var cpfValido = AtribuirCpfResponsavel(cpfResponsavel);
            if (!cpfValido)
                throw new ArgumentException(cpfValido.Mensagem, nameof(Cpf));
        }

        public void InativarFamilia() => Ativa = false;
        public void AtivarFamilia() => Ativa = true;
        public void AtribuirConjuge(string conjuge) => NomeConjuge = conjuge;
        public void AtribuirQuantidadeDeFilhos(int filhos) => QuantidadeFilhos = filhos;

        public ResultadoValidacaoEntidade AtribuirResponsavel(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return new ResultadoValidacaoEntidade(false, "Nome do Reponsável é obrigatório.");

            if (nome.Length > 150)
                return new ResultadoValidacaoEntidade(false,
                    "Nome do Reponsável deve conter no máximo 150 caracteres.");

            NomeResponsavel = nome;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirCpfResponsavel(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return new ResultadoValidacaoEntidade(false, "CPF do Reponsável é obrigatório.");

            CpfResponsavel = new Cpf(cpf);

            if (!CpfResponsavel.EhValido)
                return new ResultadoValidacaoEntidade(false, "CPF do Reponsável inválido.");

            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return new ResultadoValidacaoEntidade(false, "CEP é obrigatório.");

            if (cep.Length != 8)
                return new ResultadoValidacaoEntidade(false, "CEP deve conter 8 caracteres.");

            Cep = cep;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
                return new ResultadoValidacaoEntidade(false, "Logradouro é obrigatório.");

            if (logradouro.Length > 200)
                return new ResultadoValidacaoEntidade(false, "Logradouro deve conter no máximo 200 caracteres.");

            Logradouro = logradouro;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
                return new ResultadoValidacaoEntidade(false, "Bairro é obrigatório.");

            if (bairro.Length > 80)
                return new ResultadoValidacaoEntidade(false, "Bairro deve conter no máximo 80 caracteres.");

            Bairro = bairro;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
                return new ResultadoValidacaoEntidade(false, "Cidade é obrigatória.");

            if (cidade.Length > 150)
                return new ResultadoValidacaoEntidade(false, "Cidade deve conter no máximo 150 caracteres.");

            Cidade = cidade;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirUf(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf))
                return new ResultadoValidacaoEntidade(false, "UF é obrigatória.");

            if (uf.Length != 2)
                return new ResultadoValidacaoEntidade(false, "UF deve conter 2 caracteres.");

            Uf = uf;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirComplemento(string complemento)
        {
            if (complemento?.Length > 50)
                return new ResultadoValidacaoEntidade(false, "Complemento deve ter no máximo 50 caracteres.");

            Complemento = complemento;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirNumero(string numero)
        {
            if (numero.Length > 5)
                return new ResultadoValidacaoEntidade(false, "Número deve conter no máximo 5 caracteres.");

            Numero = numero;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirTelefone(string numero)
        {
            if (numero.Length > 15)
                return new ResultadoValidacaoEntidade(false, "Telefone deve conter no máximo 15 caracteres");

            Telefone = numero;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirObservacao(string observacoes)
        {
            if (observacoes?.Length > 200)
                return new ResultadoValidacaoEntidade(false, "Observações deve conter no máximo 200 caracteres.");

            Observacoes = observacoes;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }
    }
}