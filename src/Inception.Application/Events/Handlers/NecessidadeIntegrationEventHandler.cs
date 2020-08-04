using EventBus.Domain;
using Inception.Application.Events.Entities;
using Inception.Domain.Entities;
using Inception.Domain.Interfaces.Repositories;
using Inception.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inception.Application.Events.Handlers
{
    public class NecessidadeIntegrationEventHandler : IIntegrationEventHandler<NecessidadeIntegrationEvent>
    {
        private readonly IInceptionsService _inceptionsService;
        private readonly IInceptionsRepository _inceptionsRepository;

        public NecessidadeIntegrationEventHandler(IInceptionsService inceptionsService, IInceptionsRepository inceptionsRepository)
        {
            this._inceptionsService = inceptionsService;
            this._inceptionsRepository = inceptionsRepository;
        }
        public void Handle(NecessidadeIntegrationEvent @event)
        {
            var inception = _inceptionsRepository.GetInceptionsByIdWithList(@event.IdInceptions);
            var necessidade = new Necessidade(@event.Descricao, inception, @event.Abreviacao);
            _inceptionsService.AddNecessidadeInInception(inception, necessidade);
        }
    }
}
