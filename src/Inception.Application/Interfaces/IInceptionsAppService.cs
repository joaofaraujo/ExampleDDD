using Inception.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inception.Application.Interfaces
{
    public interface IInceptionsAppService
    {
        Task InsertedInceptionsAsync(InceptionsViewModel inceptionsViewModel);
        Task<InceptionsViewModel> GetInception(long idInception);
    }
}
