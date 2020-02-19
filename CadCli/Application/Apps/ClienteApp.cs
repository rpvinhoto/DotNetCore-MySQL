using Application.Interfaces;
using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Apps
{
    public class ClienteApp : IClienteApp
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteApp(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        public void Delete(Cliente entity)
        {
            _clienteInterface.Delete(entity);
        }

        public void Delete(long id)
        {
            _clienteInterface.Delete(id);
        }

        public Cliente Get(Expression<Func<Cliente, bool>> predicate)
        {
            return _clienteInterface.Get(predicate);
        }

        public Task<Cliente> GetAsync(Expression<Func<Cliente, bool>> predicate)
        {
            return _clienteInterface.GetAsync(predicate);
        }

        public Cliente GetById(long id)
        {
            return _clienteInterface.GetById(id);
        }

        public Task<Cliente> GetByIdAsync(long id)
        {
            return _clienteInterface.GetByIdAsync(id);
        }

        public IEnumerable<Cliente> GetMany(Expression<Func<Cliente, bool>> predicate = null)
        {
            return _clienteInterface.GetMany(predicate);
        }

        public void Insert(Cliente entity)
        {
            _clienteInterface.Insert(entity);
        }

        public Task InsertAsync(Cliente entity)
        {
            return _clienteInterface.InsertAsync(entity);
        }

        public void Update(Cliente entity)
        {
            _clienteInterface.Update(entity);
        }
    }
}