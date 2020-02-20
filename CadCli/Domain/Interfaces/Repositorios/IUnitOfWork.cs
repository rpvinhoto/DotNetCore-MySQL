using Domain.Entidades;
using System;

namespace Domain.Interfaces.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorioBase<Cliente> ClienteRepositorio { get; }
        void Save();
    }
}