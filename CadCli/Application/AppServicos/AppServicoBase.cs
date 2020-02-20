using Application.Interfaces;
using Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.AppServicos
{
    public class AppServicoBase<T> : IAppServicoBase<T> where T : class
    {
        private readonly IServicoBase<T> _servicoBase;

        public AppServicoBase(IServicoBase<T> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adicionar(T entidade)
        {
            _servicoBase.Adicionar(entidade);
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _servicoBase.AdicionarAsync(entidade);
        }

        public void Atualizar(T entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public async Task AtualizarAsync(T entidade)
        {
            await _servicoBase.AtualizarAsync(entidade);
        }

        public bool Existe(long id)
        {
            return _servicoBase.Existe(id);
        }

        public T ObterPorId(long id)
        {
            return _servicoBase.ObterPorId(id);
        }

        public async Task<T> ObterPorIdAsync(long id)
        {
            return await _servicoBase.ObterPorIdAsync(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _servicoBase.ObterTodos();
        }

        public void Remover(T entidade)
        {
            _servicoBase.Remover(entidade);
        }

        public void Remover(long id)
        {
            _servicoBase.Remover(id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _servicoBase.Dispose();
        }
    }
}