using Inception.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inception.Application.ViewModels
{
    public class InceptionsViewModel
    {
        public InceptionsViewModel()
        {

        }

        public InceptionsViewModel(Inceptions inceptions)
        {
            if (inceptions == null)
                return;

            this.Id = inceptions.Id;
            this.Nome = inceptions.Nome;
            this.Identificador = inceptions.Identificador;
            this.DataCriacao = inceptions.DataCriacao;
            this.DataAtualizacao = inceptions.DataAtualizacao;
            this.Problemas = inceptions?.Problemas?.ToDictionary(x => x.Abreviacao, x => x.Descricao);
            this.Necessidades = inceptions?.Necessidades?.ToDictionary(x => x.Abreviacao, x => x.Descricao);
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Identificador { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Dictionary<string, string> Problemas { get; set; }
        public Dictionary<string, string> Necessidades { get; set; }
    }
}
