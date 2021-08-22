using System;
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
        public Endereco Endereco { get; private set; }
        public Igreja Paroquia { get; private set; }

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

        public void AtribuirEndereco(Endereco endereco) => Endereco = endereco;
        public void AtribuirParoquia(Igreja paroquia) => Paroquia = paroquia;
        public void InativarFamilia() => Ativa = false;
        public void AtivarFamilia() => Ativa = true;
        public void AtribuirConjuge(string conjuge) => NomeConjuge = conjuge;
        public void AtribuirQuantidadeDeFilhos(int filhos) => QuantidadeFilhos = filhos;
        public ResultadoValidacaoEntidade AtribuirResponsavel(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return new ResultadoValidacaoEntidade(false, "Nome do Reponsável é obrigatório.");

            if (nome.Length > 150)
                return new ResultadoValidacaoEntidade(false, "Nome do Reponsável deve conter no máximo 150 caracteres.");

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
    }
}
