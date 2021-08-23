using System;
using System.Text;
using PromocaoHumana.Web.Domain.Structs;
using PromocaoHumana.Web.Models.Igreja;

namespace PromocaoHumana.Web.Domain
{
    public class Igreja : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Paroco { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Igreja()
        {
        }

        public Igreja(IgrejaViewModel novaIgreja)
        {
            AtribuirParoco(novaIgreja.Paroco);

            var nomeValido = AtribuirNome(novaIgreja.Nome);
            var cnpjValido = AtribuirCnpj(novaIgreja.Cnpj);

            var erros = new StringBuilder();
            if (!nomeValido.Valida)
                erros.AppendLine(nomeValido.Mensagem);

            if (!cnpjValido.Valida)
                erros.AppendLine(cnpjValido.Mensagem);

            if (erros.Length > 0)
                throw new ArgumentException(erros.ToString());
        }

        public ResultadoValidacaoEntidade AtribuirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return new ResultadoValidacaoEntidade(false, "Nome é obrigatório.");

            if (nome.Length > 150)
                return new ResultadoValidacaoEntidade(false, "Nome deve conter no máximo 150 caracteres.");

            Nome = nome;
            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public ResultadoValidacaoEntidade AtribuirCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return new ResultadoValidacaoEntidade(false, "CNPJ é obrigatório.");

            Cnpj = new Cnpj(cnpj);

            if (!Cnpj.EhValido)
                return new ResultadoValidacaoEntidade(false, "CNPJ inválido.");

            return new ResultadoValidacaoEntidade(true, string.Empty);
        }

        public void AtribuirEndereco(Endereco endereco) => Endereco = endereco;
        public void AtribuirParoco(string nomeParoco) => Paroco = nomeParoco;
    }
}