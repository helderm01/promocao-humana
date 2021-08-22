using System;
using PromocaoHumana.Web.Domain.Enums;

namespace PromocaoHumana.Web.Domain
{
    public class Doacao : EntidadeBase
    {
        public DateTime DataRetirada { get; private set; } = DateTime.Today;
        public string Descricao { get; set; }
        public Familia Familia { get; set; }
        public DoacaoTipo Tipo { get; set; }
        public string QuemRetirou { get; set; }
        public Igreja LocalRetirada { get; set; }

        protected Doacao()
        {
        }
    }
}