using System;
using System.Collections.Generic;

namespace Inception.Domain.Entities
{
    public class Inceptions
    {
        public Inceptions(string nome, DateTime dataCriacao)
        {
            this.Nome = nome;
            this.DataCriacao = dataCriacao;
        }

        protected Inceptions()
        {

        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Identificador { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; set; }
        public List<Problema> Problemas { get; set; }
        public List<Necessidade> Necessidades { get; set; }

        /// <summary>
        /// Set a new Identity
        /// </summary>
        /// <param name="ano"></param>
        /// <param name="ultimoNumeroGerado"></param>
        /// <returns></returns>
        public Inceptions SetNewIdentificador(long ultimoNumeroGerado)
        {
            this.Identificador = $"IN-{this.DataCriacao.Year}-{ultimoNumeroGerado + 1}";
            return this;
        }

        public Inceptions UpdateInceptions(string nome)
        {
            this.Nome = nome;
            this.DataAtualizacao = DateTime.Now;

            return this;
        }
    }
}
