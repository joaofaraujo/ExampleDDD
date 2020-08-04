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
    public class ProblemaIntegrationEventHandler : IIntegrationEventHandler<ProblemaIntegrationEvent>
    {
        private readonly IInceptionsService _inceptionsService;
        private readonly IInceptionsRepository _inceptionsRepository;

        public ProblemaIntegrationEventHandler(IInceptionsService inceptionsService, IInceptionsRepository inceptionsRepository)
        {
            this._inceptionsService = inceptionsService;
            this._inceptionsRepository = inceptionsRepository;
        }
        public void Handle(ProblemaIntegrationEvent @event)
        {
            var inception = _inceptionsRepository.GetInceptionsByIdWithList(@event.IdInceptions);
            var problema = new Problema(@event.Descricao, inception, @event.Abreviacao);
            _inceptionsService.AddProblemaInInception(inception, problema);
        }
    }
}
