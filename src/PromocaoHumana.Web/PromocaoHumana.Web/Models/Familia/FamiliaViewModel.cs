using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PromocaoHumana.Web.Models.Endereco;

namespace PromocaoHumana.Web.Models.Familia
{
    public class FamiliaViewModel
    {
        public int Id { get; set; }

        [ReadOnly(true)] public DateTime DataCadastro { get; set; } = DateTime.Today;

        [ReadOnly(true)] public bool Ativa { get; set; } = true;

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string CpfResponsavel { get; set; }

        [StringLength(150, ErrorMessage = "{0} não pode ter mais que {1} caracteres.")]
        public string NomeConjuge { get; set; }

        public int QuantidadeFilhos { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int ParoquiaId { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public EnderecoViewModel Endereco { get; set; }
    }
}