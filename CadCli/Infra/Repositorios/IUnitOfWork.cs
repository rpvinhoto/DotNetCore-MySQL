using Domain.Entidades;
using System;

namespace Infra.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        RepositorioBase<Cliente> ClienteRepositorio { get; }
        void Save();
    }
}