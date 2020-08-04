using Inception.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inception.Domain.Interfaces.Services
{
    public interface IInceptionsService
    {
        Task InsertInceptionAsync(Inceptions inception);
        void AddNecessidadeInInception(Inceptions inception, Necessidade necessidade);
        void AddProblemaInInception(Inceptions inception, Problema necessidade);
    }
}
