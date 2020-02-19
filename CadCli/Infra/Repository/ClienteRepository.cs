using Domain.Entidades;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteInterface
    {
        public ClienteRepository(CadCliContext context) : base(context)
        {
        }
    }
}
