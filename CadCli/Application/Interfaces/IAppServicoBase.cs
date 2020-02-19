using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppServicoBase<T> : IDisposable where T : class
    {
        void Adicionar(T entidade);
        Task AdicionarAsync(T entidade);
        void Atualizar(T entidade);
        Task AtualizarAsync(T entidade);
        bool Existe(long id);
        T ObterPorId(long id);
        Task<T> ObterPorIdAsync(long id);
        IEnumerable<T> ObterTodos();
        void Remover(T entidade);
        void Remover(long id);
    }
}