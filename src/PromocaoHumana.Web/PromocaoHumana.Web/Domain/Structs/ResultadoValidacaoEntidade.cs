namespace PromocaoHumana.Web.Domain.Structs
{
    public struct ResultadoValidacaoEntidade
    {
        public bool Valida { get; private set; }
        public string Mensagem { get; private set; }

        public ResultadoValidacaoEntidade(bool entidadeValida, string mensagem)
        {
            Valida = entidadeValida;
            Mensagem = mensagem;
        }

        public static implicit operator ResultadoValidacaoEntidade(string erro)
        {
            if (string.IsNullOrEmpty(erro))
                return new ResultadoValidacaoEntidade(true, string.Empty);
            else
                return new ResultadoValidacaoEntidade(false, erro);
        }

        public static implicit operator bool(ResultadoValidacaoEntidade retorno)
        {
            return retorno.Valida;
        }
    }
}
