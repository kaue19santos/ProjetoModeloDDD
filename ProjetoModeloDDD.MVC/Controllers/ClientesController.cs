using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;

        private readonly IMapper _mapper;

        public ClientesController(IClienteAppService clienteApp, IMapper mapper)
        {
            _clienteApp= clienteApp;
            _mapper = mapper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            var clientes = _clienteApp.GetAll();
            var clienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

            return View(clienteViewModel);
        }

        public IActionResult Especiais()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());

            return View(clienteViewModel);
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {

            if (!ModelState.IsValid)
                return View(clienteViewModel);

            var clienteDomain = _mapper.Map<Cliente>(clienteViewModel);

            _clienteApp.Add(clienteDomain);

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return View(clienteViewModel);

            var clienteDomain = _mapper.Map<Cliente>(clienteViewModel);

            _clienteApp.Update(clienteDomain);

            return RedirectToAction(nameof(Index));
        }

        // GET: CLientes/Delete/5
        public IActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: CLientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction(nameof(Index));
        }
    }
}
