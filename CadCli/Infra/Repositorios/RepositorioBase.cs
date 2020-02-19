using Domain.Interfaces.Repositorios;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly CadCliContext _db;

        public RepositorioBase(CadCliContext context)
        {
            _db = context;
        }

        public void Adicionar(T entidade)
        {
            _db.Set<T>().Add(entidade);
            //_db.SaveChanges();
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _db.Set<T>().AddAsync(entidade);
            //await _db.SaveChangesAsync();
        }

        public void Atualizar(T entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
            //_db.SaveChanges();
        }

        public async Task AtualizarAsync(T entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
            //await _db.SaveChangesAsync();
        }

        public bool Existe(long id)
        {
            return _db.Set<T>().Find(id) != null;
        }

        public T ObterPorId(long id)
        {
            return _db.Set<T>().Find(id);
        }

        public async Task<T> ObterPorIdAsync(long id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _db.Set<T>();
        }

        public void Remover(T entidade)
        {
            _db.Set<T>().Remove(entidade);
            //_db.SaveChanges();
        }

        public void Remover(long id)
        {
            var entidade = _db.Set<T>().Find(id);
            Remover(entidade);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}