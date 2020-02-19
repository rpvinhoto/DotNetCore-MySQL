using Domain.Entidades;
using System;

namespace Infra.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Cliente> ClienteRepositorio { get; }
        void Save();
    }
}