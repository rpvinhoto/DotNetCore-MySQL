using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Context;
using System;

namespace Infra.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadCliContext _context;
        private IRepositorioBase<Cliente> _clienteRepositorio;

        public UnitOfWork(CadCliContext context)
        {
            _context = context;
        }

        public IRepositorioBase<Cliente> ClienteRepositorio
        {
            get
            {
                return _clienteRepositorio = _clienteRepositorio ?? new RepositorioBase<Cliente>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}