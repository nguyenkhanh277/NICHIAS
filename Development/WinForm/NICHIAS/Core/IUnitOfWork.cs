using NICHIAS.Core.Repositories;
using System;
using NICHIAS.Persistence;

namespace NICHIAS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}