namespace Inception.Domain.Entities
{
    public class Problema
    {
        public Problema(string descricao, Inceptions inceptions, string abreviacao)
        {
            this.Descricao = descricao;
            this.Inceptions = inceptions;
            this.Abreviacao = abreviacao;
        }

        protected Problema()
        {
        }

        public long Id { get; private set; }
        public string Descricao { get; private set; }
        public long IdInceptions { get; private set; }
        public Inceptions Inceptions { get; private set; }
        public string Abreviacao { get; private set; }
    }
}
