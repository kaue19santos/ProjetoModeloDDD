using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProjetoModeloDDD.Infra.Data.Contexto;

namespace ProjetoModeloDDD.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjetoModeloContext>
    {
        public ProjetoModeloContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjetoModeloContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=ProjetoModelo;User Id=sa;Password=Senha123!;TrustServerCertificate=True;");

            return new ProjetoModeloContext(optionsBuilder.Options);
        }
    }
}
