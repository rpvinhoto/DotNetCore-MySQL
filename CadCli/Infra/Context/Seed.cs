using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Context
{
    public class Seed
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 1,
                    Nome = "Maria Oliveira",
                    DataNascimento = new DateTime(1950, 6, 10),
                    Sexo = Sexo.Feminino,
                    Cep = "86975-000",
                    Estado = "PR",
                    Cidade = "Mandaguari",
                    Bairro = "Centro",
                    Endereco = "Avenida Amazonas",
                    Numero = 123,
                    Complemento = "B"
                });

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 2,
                    Nome = "José da Silva",
                    DataNascimento = new DateTime(1983, 4, 16),
                    Sexo = Sexo.Masculino,
                    Cep = "87013-210",
                    Estado = "PR",
                    Cidade = "Maringá",
                    Bairro = "Zona 01",
                    Endereco = "Av. Tamandaré",
                    Numero = 100
                });
        }
    }
}