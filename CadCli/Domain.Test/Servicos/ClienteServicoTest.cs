using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Servicos;
using Domain.Test.Mock;
using NUnit.Framework;
using System;
using System.Linq;

namespace Domain.Test.Servicos
{
    public class ClienteServicoTest
    {
        private IUnitOfWork _unitOfWork;
        private IClienteRepositorio _clienteRepositorio;
        private IClienteServico _clienteServico;

        [SetUp]
        public void Setup()
        {
            _clienteRepositorio = new ClienteRepositorioMock();
            _unitOfWork = new UnitOfWorkMock(_clienteRepositorio);
            _clienteServico = new ClienteServico(_unitOfWork);
        }

        [Test]
        public void Deve_adicionar_um_cliente()
        {
            var cliente = new Cliente
            {
                Nome = "Cliente 1",
                DataNascimento = new DateTime(2000, 1, 1),
                Sexo = Sexo.Masculino
            };

            _clienteServico.Adicionar(cliente);

            var clientes = _clienteServico.ObterTodos().ToList();

            Assert.AreEqual(1, clientes.Count);
            Assert.AreEqual("Cliente 1", clientes.First().Nome);
            Assert.AreEqual(new DateTime(2000, 1, 1), clientes.First().DataNascimento);
            Assert.AreEqual(Sexo.Masculino, clientes.First().Sexo);
        }

        [Test]
        public void Deve_adicionar_e_atualizar_um_cliente()
        {
            var cliente = new Cliente
            {
                Nome = "Cliente 1",
                DataNascimento = new DateTime(2000, 1, 1),
                Sexo = Sexo.Masculino
            };

            _clienteServico.Adicionar(cliente);

            var clientes = _clienteServico.ObterTodos().ToList();

            cliente.Nome = "Cliente 2";

            _clienteServico.Atualizar(cliente);

            Assert.AreEqual(1, clientes.Count);
            Assert.AreEqual("Cliente 2", clientes.First().Nome);
        }

        [Test]
        public void Deve_adicionar_um_cliente_e_buscar_por_id()
        {
            var cliente = new Cliente
            {
                Nome = "Cliente 1",
                DataNascimento = new DateTime(2000, 1, 1),
                Sexo = Sexo.Masculino
            };

            _clienteServico.Adicionar(cliente);

            var registro = _clienteServico.ObterPorId(cliente.ClienteId);

            Assert.AreEqual(cliente.ClienteId, registro.ClienteId);
            Assert.AreEqual(cliente.Nome, registro.Nome);
        }

        [Test]
        public void Deve_adicionar_e_remover_um_cliente()
        {
            var cliente = new Cliente
            {
                Nome = "Cliente 1",
                DataNascimento = new DateTime(2000, 1, 1),
                Sexo = Sexo.Masculino
            };

            _clienteServico.Adicionar(cliente);
            _clienteServico.Remover(cliente);

            var clientes = _clienteServico.ObterTodos().ToList();

            Assert.AreEqual(0, clientes.Count);
        }
    }
}