using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class CadCliContext : DbContext
    {
        public CadCliContext(DbContextOptions<CadCliContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
    }
}