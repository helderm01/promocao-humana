using System;
using System.Text;
using PromocaoHumana.Web.Domain.Structs;
using PromocaoHumana.Web.Models.Endereco;

namespace PromocaoHumana.Web.Domain
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        protected Endereco() { }
        public Endereco(NovoEnderecoViewModel command)
        {
            AtribuirNumero(command.Numero);
            AtribuirComplemento(command.Complemento);

            var cepValido = AtribuirCep(command.Cep);
            var logradouroValido = AtribuirLogradouro(command.Logradouro);
            var bairroValido = AtribuirBairro(command.Bairro);
            var cidadeValida = AtribuirCidade(command.Cidade);
            var ufValida = AtribuirUf(command.Uf);

            var erros = new StringBuilder();
            if (!cepValido.Valida)
                erros.AppendLine(cepValido.Mensagem);

            if (!logradouroValido.Valida)
                erros.AppendLine(logradouroValido.Mensagem);

            if (!bairroValido.Valida)
                erros.AppendLine(bairroValido.Mensagem);

            if (!cidadeValida.Valida)
                erros.AppendLine(cidadeValida.Mensagem);

            if (!ufValida.Valida)
                erros.AppendLine(ufValida.Mensagem);

            if (erros.Length > 0)
                throw new ArgumentException(erros.ToString());
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
            if (complemento.Length > 50)
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
    }
}
