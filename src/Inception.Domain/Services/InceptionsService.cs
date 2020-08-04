using Inception.Domain.Entities;
using Inception.Domain.Interfaces.Repositories;
using Inception.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inception.Domain.Services
{
    public class InceptionsService : IInceptionsService
    {
        private readonly IInceptionsRepository _inceptionRepository;

        public InceptionsService(IInceptionsRepository inceptionRepository)
        {
            this._inceptionRepository = inceptionRepository;
        }

        public async Task InsertInceptionAsync(Inceptions inception)
        {
            if (inception == null)
                throw new ArgumentNullException("Inception está nula"); //TODO: Trocar para evento de dominio

            _inceptionRepository.OpenTransaction();

            try
            {
                var lastInceptionGenerated = _inceptionRepository.GetNumberFromInceptionsInYear(inception.DataCriacao.Year);
                inception.SetNewIdentificador(lastInceptionGenerated);
                await _inceptionRepository.InsertAsync(inception);
                _inceptionRepository.CommitTransaction();
            }
            catch
            {
                _inceptionRepository.RollbackTransaction();
                throw;
            }
        }

        public void AddProblemaInInception(Inceptions inception, Problema problema)
        {
            inception.Problemas.Add(problema);
            inception.DataAtualizacao = DateTime.Now;
            _inceptionRepository.Update(inception);
            _inceptionRepository.Save();
        }

        public void AddNecessidadeInInception(Inceptions inception, Necessidade necessidade)
        {
            inception.Necessidades.Add(necessidade);
            inception.DataAtualizacao = DateTime.Now;
            _inceptionRepository.Update(inception);
            _inceptionRepository.Save();
        }
    }
}
