using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;
        private readonly IMapper _mapper;

        public ProdutosController(
            IProdutoAppService produtoApp,
            IClienteAppService clienteApp,
            IMapper mapper)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
            _mapper = mapper;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            var produtos = _produtoApp.GetAll();
            var produtoViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);

            return View(produtoViewModel);
        }

        // GET: Produtos/Details/5
        public IActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);
                return View(produtoViewModel);
            }

            var produtoDomain = _mapper.Map<Produto>(produtoViewModel);
            _produtoApp.Add(produtoDomain);

            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);
                return View(produtoViewModel);
            }

            var produtoDomain = _mapper.Map<Produto>(produtoViewModel);
            _produtoApp.Update(produtoDomain);

            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction(nameof(Index));
        }
    }
}
