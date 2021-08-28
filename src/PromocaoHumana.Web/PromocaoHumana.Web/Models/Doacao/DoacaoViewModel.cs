using System.ComponentModel;

namespace PromocaoHumana.Web.Models.Doacao
{
    public class DoacaoViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("Mês retirada")]
        public string MesRetirada { get;  set; }
        
        [DisplayName("Descrição")]
        public string Descricao { get;  set; }
        
        [DisplayName("Família")]
        public string Familia { get;  set; }
        public int? FamiliaId { get; set; }
        
        [DisplayName("Local")]
        public string LocalRetirada { get;  set; }
        public int? LocalRetiradaId { get;  set; }
        
        [DisplayName("Quem retirou?")]
        public string QuemRetirou { get;  set; }
    }
}