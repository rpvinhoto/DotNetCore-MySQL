using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicoBase<T> : IServicoBase<T> where T : class
    {
        private readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(T entidade)
        {
            _repositorio.Adicionar(entidade);
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _repositorio.AdicionarAsync(entidade);
        }

        public void Atualizar(T entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public async Task AtualizarAsync(T entidade)
        {
            await _repositorio.AtualizarAsync(entidade);
        }

        public bool Existe(long id)
        {
            return _repositorio.Existe(id);
        }

        public T ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }

        public async Task<T> ObterPorIdAsync(long id)
        {
            return await _repositorio.ObterPorIdAsync(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public void Remover(T entidade)
        {
            _repositorio.Remover(entidade);
        }

        public void Remover(long id)
        {
            _repositorio.Remover(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _repositorio.Dispose();
        }
    }
}