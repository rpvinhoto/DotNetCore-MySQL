using Application.Interfaces;
using AutoMapper;
using CadCliWeb.Models;
using Domain.Entidades;
using Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CadCliWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteApp _clienteApp;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientesController(IClienteApp clienteApp, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _clienteApp = clienteApp;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View(_clienteApp.GetMany());
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

                await _clienteApp.InsertAsync(entidade);
                _unitOfWork.Save();

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

                _clienteApp.Update(entidade);
                _unitOfWork.Save();

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
            _clienteApp.Delete(id);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> Get(long? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _clienteApp.GetByIdAsync(id.Value);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }
    }
}