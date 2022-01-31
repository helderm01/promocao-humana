using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PromocaoHumana.Web.Models.Familia
{
    public class FamiliaViewModel
    {
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Data do cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Today;

        [ReadOnly(true)] public bool Ativa { get; set; } = true;

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        [DisplayName("Nome do responsável")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        [DisplayName("CPF do responsável")]
        public string CpfResponsavel { get; set; }

        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        [DisplayName("Nome do conjuge")]
        public string NomeConjuge { get; set; }

        [DisplayName("Quantidade de filhos")]
        public int QuantidadeFilhos { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        [DisplayName("CEP")]
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
        [DisplayName("UF")]
        public string Uf { get; set; }
        
        [DisplayName("Observações")]
        [StringLength(200, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string Observacoes { get; set; }
    }
}