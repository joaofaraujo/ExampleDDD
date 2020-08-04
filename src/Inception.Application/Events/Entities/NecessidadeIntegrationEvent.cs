using EventBus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inception.Application.Events.Entities
{
    public class NecessidadeIntegrationEvent : IntegrationEvent
    {
        public long IdInceptions { get; set; }
        public string Descricao { get; set; }
        public string Abreviacao { get; set; }
    }
}
