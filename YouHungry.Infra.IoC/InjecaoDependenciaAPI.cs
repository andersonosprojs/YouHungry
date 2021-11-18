using CleanArchMvc.Application.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using YouHungry.Aplicacao.Interfaces;
using YouHungry.Aplicacao.Services;
using YouHungry.Dominio.Interfaces;
using YouHungry.Infra.Dados.Contexto;
using YouHungry.Infra.Dados.Repositories;

namespace YouHungry.Infra.IoC
{
    public static class InjecaoDependenciaAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IPratoRepository, PratoRepository>();
            services.AddScoped<IAcompanhamentoRepository, AcompanhamentoRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IPratoService, PratoService>();
            services.AddScoped<IAcompanhamentoService, AcompanhamentoService>();

            services.AddAutoMapper(typeof(DominioParaDTOProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("YouHungry.Aplicacao");
            services.AddMediatR(myHandlers);

            return services;
        }

    }
}
