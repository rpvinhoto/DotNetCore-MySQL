using Application.Interfaces;
using Domain.Entidades;
using Domain.Interfaces.Servicos;
using Infra.Repositorios;

namespace Application.AppServicos
{
    public class ClienteAppServico : AppServicoBase<Cliente>, IClienteAppServico
    {
        public ClienteAppServico(IClienteServico clienteServico, IUnitOfWork unitOfWork) : base(clienteServico, unitOfWork)
        {
        }
    }
}