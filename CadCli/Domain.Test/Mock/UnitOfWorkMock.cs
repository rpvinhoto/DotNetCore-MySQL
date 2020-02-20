using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using System;

namespace Domain.Test.Mock
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public UnitOfWorkMock(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IRepositorioBase<Cliente> ClienteRepositorio => _clienteRepositorio;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
        }
    }
}