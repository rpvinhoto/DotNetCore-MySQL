using Application.Interfaces;
using AutoMapper;
using CadCliWeb.Models;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadCliWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppServico _clienteAppServico;
        private readonly IMapper _mapper;

        public ClientesController(IClienteAppServico clienteAppServico, IMapper mapper)
        {
            _clienteAppServico = clienteAppServico;
            _mapper = mapper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(_clienteAppServico.ObterTodos()));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            return await Get(id);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,DataNascimento,Sexo,Cep,Endereco,Numero,Complemento,Bairro,Estado,Cidade")] ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var entidade = _mapper.Map<Cliente>(cliente);

                await _clienteAppServico.AdicionarAsync(entidade);

                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            return await Get(id);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("ClienteId,Nome,DataNascimento,Sexo,Cep,Endereco,Numero,Complemento,Bairro,Estado,Cidade")] ClienteViewModel cliente)
        {
            if (id != cliente.ClienteId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var entidade = _mapper.Map<Cliente>(cliente);

                _clienteAppServico.Atualizar(entidade);

                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            return await Get(id);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _clienteAppServico.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> Get(long? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _clienteAppServico.ObterPorIdAsync(id.Value);

            if (cliente == null)
                return NotFound();

            return View(_mapper.Map<ClienteViewModel>(cliente));
        }
    }
}