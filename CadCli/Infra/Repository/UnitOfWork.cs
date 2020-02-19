using Domain.Entidades;
using Infra.Context;
using System;

namespace Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadCliContext _context;
        private GenericRepository<Cliente> _clienteRepositorio;

        public UnitOfWork(CadCliContext context)
        {
            _context = context;
        }

        public GenericRepository<Cliente> ClienteRepositorio
        {
            get
            {
                if (_clienteRepositorio == null)
                    _clienteRepositorio = new GenericRepository<Cliente>(_context);

                return _clienteRepositorio;
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