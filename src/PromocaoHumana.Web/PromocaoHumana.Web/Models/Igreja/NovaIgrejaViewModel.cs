using PromocaoHumana.Web.Models.Endereco;

namespace PromocaoHumana.Web.Models.Igreja
{
    public class NovaIgrejaViewModel
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Paroco { get; set; }
        public NovoEnderecoViewModel Endereco { get; set; }
    }
}