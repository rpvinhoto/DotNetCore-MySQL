using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Context;

namespace Infra.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(CadCliContext context) : base(context)
        {
        }
    }
}