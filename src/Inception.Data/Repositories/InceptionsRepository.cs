using Inception.Data.Contexts;
using Inception.Data.Repositories.Base;
using Inception.Domain.Entities;
using Inception.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Inception.Data.Repositories
{
    public class InceptionsRepository : BaseRepository<Inceptions>, IInceptionsRepository
    {
        public InceptionsRepository(InceptionContext inceptionContext) : base(inceptionContext)
        {
        }

        public async Task<Inceptions> GetInceptionsByIdWithListAsync(long id)
        {
            return (await base.SelectAsync(x => x.Id == id, x => x.Problemas, x => x.Necessidades)).SingleOrDefault();
        }

        public Inceptions GetInceptionsByIdWithList(long id)
        {
            return base.Select(x => x.Id == id, x => x.Problemas, x => x.Necessidades).SingleOrDefault();
        }

        public int GetNumberFromInceptionsInYear(int ano)
        {
            return base.Select(x => x.DataCriacao.Year == ano).Count();
        }
    }
}
