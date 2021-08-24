using System.ComponentModel.DataAnnotations;

namespace PromocaoHumana.Web.Models.Endereco
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Cep { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Logradouro { get; set; }
        
        [StringLength(5, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Numero { get; set; }
        
        [StringLength(50, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Complemento { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(80, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Bairro { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Uf { get; set; }
    }
}