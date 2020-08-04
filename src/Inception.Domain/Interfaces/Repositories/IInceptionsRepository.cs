using Inception.Domain.Entities;
using Inception.Domain.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace Inception.Domain.Interfaces.Repositories
{
    public interface IInceptionsRepository : IBaseRepository<Inceptions>
    {
        int GetNumberFromInceptionsInYear(int ano);
        Task<Inceptions> GetInceptionsByIdWithListAsync(long id);
        Inceptions GetInceptionsByIdWithList(long id);
    }
}
