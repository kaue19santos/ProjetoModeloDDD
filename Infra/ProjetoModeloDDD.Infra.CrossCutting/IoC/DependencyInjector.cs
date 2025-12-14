using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;

using ProjetoModeloDDD.Infra.Data.Contexto;
using ProjetoModeloDDD.Infra.Data.Repositories;

using ProjetoModeloDDD.Application.Interfaces;
using ProjetoModeloDDD.Application;

namespace ProjetoModeloDDD.Infra.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
           
            services.AddDbContext<ProjetoModeloContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
