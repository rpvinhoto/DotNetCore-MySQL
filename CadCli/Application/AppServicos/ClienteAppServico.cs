using Application.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Servicos;

namespace Application.AppServicos
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        public ClienteAppServico(IClienteServico clienteServico) : base(clienteServico)
        {
        }
    }
}