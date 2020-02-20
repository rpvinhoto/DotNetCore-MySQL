using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;

namespace Domain.Servicos
{
    public class ClienteServico : ServicoBase<Cliente>, IClienteServico
    {
        public ClienteServico(IUnitOfWork unitOfWork) : base(unitOfWork.ClienteRepositorio, unitOfWork)
        {
        }
    }
}