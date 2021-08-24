using System.ComponentModel.DataAnnotations;

namespace PromocaoHumana.Web.Models.Igreja
{
    public class IgrejaViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(18, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Cnpj { get; set; }
    }
}