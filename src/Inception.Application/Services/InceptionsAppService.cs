using Inception.Application.Interfaces;
using Inception.Application.ViewModels;
using Inception.Domain.Entities;
using Inception.Domain.Interfaces.Repositories;
using Inception.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Inception.Application.Services
{
    public class InceptionsAppService : IInceptionsAppService
    {
        private readonly IInceptionsService _inceptionsService;
        private readonly IInceptionsRepository _inceptionsRepository;

        public InceptionsAppService(IInceptionsService inceptionsService, IInceptionsRepository inceptionsRepository)
        {
            this._inceptionsService = inceptionsService;
            this._inceptionsRepository = inceptionsRepository;
        }

        public async Task InsertedInceptionsAsync(InceptionsViewModel inceptionsViewModel)
        {
            var newInception = new Inceptions(inceptionsViewModel.Nome, DateTime.Now);
            await _inceptionsService.InsertInceptionAsync(newInception);
            inceptionsViewModel.Id = newInception.Id;
        }

        public async Task<InceptionsViewModel> GetInception(long idInception)
        {
            var inception = await _inceptionsRepository.GetInceptionsByIdWithListAsync(idInception);
            var inceptionsViewModel = new InceptionsViewModel(inception);

            return inceptionsViewModel;
        }
    }
}
