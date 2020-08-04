using Inception.CrossCutting.EventsDomain.Entities;
using System;

namespace Inception.CrossCutting.EventsDomain.Interfaces
{
    public interface IHandler<in T> : IDisposable where T : EventDomain
    {
        void Handle(T message);
    }
}
