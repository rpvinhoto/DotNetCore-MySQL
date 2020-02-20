using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ClienteConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<Cliente>().Property(c => c.ClienteId).IsRequired().UseMySqlIdentityColumn();
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(c => c.DataNascimento).IsRequired().HasColumnType("date");
            modelBuilder.Entity<Cliente>().Property(c => c.Sexo).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Cep).HasMaxLength(9);
            modelBuilder.Entity<Cliente>().Property(c => c.Endereco).HasMaxLength(250);
            modelBuilder.Entity<Cliente>().Property(c => c.Complemento).HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(c => c.Bairro).HasMaxLength(100);
            modelBuilder.Entity<Cliente>().Property(c => c.Estado).HasMaxLength(2);
            modelBuilder.Entity<Cliente>().Property(c => c.Cidade).HasMaxLength(100);
        }
    }
}