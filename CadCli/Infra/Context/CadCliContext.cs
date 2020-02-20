using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Seed().Run(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}