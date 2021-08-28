using System;

namespace PromocaoHumana.Web.Domain
{
    public class Doacao : EntidadeBase
    {
        public DateTime DataRetirada { get; private set; } = DateTime.Today;
        public string MesRetirada { get; private set; }
        public string Descricao { get; private set; }
        public Familia Familia { get; private set; }
        public int? FamiliaId { get; private set; }
        public string QuemRetirou { get; private set; }
        public Igreja LocalRetirada { get; private set; }
        public int? LocalRetiradaId { get; private set; }

        protected Doacao()
        {
        }

        public Doacao(Familia familia, Igreja localRetirada, string quemRetirou)
        {
            AtribuirFamilia(familia);
            AtribuirLocalRetirada(localRetirada);
            AtribuirQuemRetirou(quemRetirou);
            
            MesRetirada = $"{DataRetirada.Month}/{DataRetirada.Year}";
        }

        public void AtribuirFamilia(Familia familia)
        {
            if (familia == null)
                throw new ArgumentNullException(nameof(Familia), "Família é obrigatória.");

            Familia = familia;
            FamiliaId = familia.Id;
        }

        public void AtribuirLocalRetirada(Igreja igreja)
        {
            if (igreja == null)
                throw new ArgumentNullException(nameof(Igreja), "Igreja é obrigatória.");

            LocalRetirada = igreja;
            LocalRetiradaId = igreja.Id;
        }

        public void AtribuirQuemRetirou(string quemRetirou)
        {
            if (string.IsNullOrWhiteSpace(quemRetirou))
                throw new ArgumentNullException(nameof(QuemRetirou), "É obrigatório informar quem retirou.");
            
            if(quemRetirou.Length > 150)
                throw new ArgumentNullException(nameof(QuemRetirou), "Quem retirou deve conter no máximo 150 caracteres.");

            QuemRetirou = quemRetirou;
        }

        public void AtribuirDescricao(string descricao)
        {
            if (descricao.Length > 250)
                throw new ArgumentNullException(nameof(Descricao), "Descrição deve conter no máximo 250 caracteres.");

            Descricao = descricao;
        }
    }
}