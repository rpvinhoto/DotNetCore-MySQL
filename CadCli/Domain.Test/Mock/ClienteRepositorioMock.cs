using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.Mock
{
    public class ClienteRepositorioMock : IClienteRepositorio
    {
        private readonly List<Cliente> registros = new List<Cliente>();

        public void Adicionar(Cliente entidade)
        {
            entidade.ClienteId = registros.Count + 1;
            registros.Add(entidade);
        }

        public Task AdicionarAsync(Cliente entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cliente entidade)
        {
            Remover(entidade);
            registros.Add(entidade);
        }

        public Task AtualizarAsync(Cliente entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Existe(long id)
        {
            return registros.Exists(r => r.ClienteId == id);
        }

        public Cliente ObterPorId(long id)
        {
            return registros.FirstOrDefault(r => r.ClienteId == id);
        }

        public Task<Cliente> ObterPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return registros;
        }

        public void Remover(Cliente entidade)
        {
            var index = registros.FindIndex(r => r.ClienteId == entidade.ClienteId);

            if (index != -1)
                registros.RemoveAt(index);
        }

        public void Remover(long id)
        {
            var index = registros.FindIndex(r => r.ClienteId == id);

            if (index != -1)
                registros.RemoveAt(index);
        }
    }
}