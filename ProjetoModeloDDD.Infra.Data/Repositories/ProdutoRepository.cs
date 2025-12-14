using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Data.Contexto;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {

        public ProdutoRepository(ProjetoModeloContext context)
            : base(context)
        {
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produto.Where(p => p.Nome == nome);
        }

        public override IEnumerable<Produto> GetAll()
        {
            return _context.Produto.Include(p => p.Cliente).ToList();
        }
    }
}

