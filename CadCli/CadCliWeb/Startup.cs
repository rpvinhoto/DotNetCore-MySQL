using Application.AppServicos;
using Application.Interfaces;
using CadCliWeb.Mapper;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Servicos;
using Infra.Context;
using Infra.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadCliWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<CadCliContext>(options => options.UseMySql(Configuration.GetConnectionString("CadCliConnection")));

            services.AddSingleton(typeof(IAppServicoBase<>), typeof(AppServicoBase<>));
            services.AddTransient<IClienteAppServico, ClienteAppServico>();

            services.AddSingleton(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddTransient<IClienteServico, ClienteServico>();

            services.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var mapperConfig = MapperConfig.Configure();
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Clientes/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Clientes}/{action=Index}/{id?}");
            });
        }
    }
}