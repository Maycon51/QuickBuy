using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using QuickBuy.Repositorio.Repositorios;

namespace QuickBuy.Web
{
    public class Startup//ponta p� para iniciar todo aplicativo, ele que traz as biblio(repositorio e dominio)
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json",optional:false, reloadOnChange:true);//determina a configura��o pro caminho do banco
            //ele n�o � opcional � obrigatorio //se alterar no config.json ele vai recarregar automatico
           
            Configuration = builder.Build();
            //ele vai construir uma interface de configura��o com base no add.json
            //o que ele vai passar � config.json pro configuration na hora de iniciar
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration.GetConnectionString("QuickBuyDB");
            //ele esta percorrendo a string de conex�o procurando o quickbuydb
            services.AddDbContext<QuickBuyContexto>(option => option

            .UseLazyLoadingProxies()//MUITO IMPORTANTE
            //ELE VAI SER RESPONSAVEL POR FAZER A VINCULA��O ENTRE AS CLASSES PARA CARREGAR AUTOMATICAMENTE NO BANCO
            //* EX:VAI PEGAR TODOS OS PEDIDOS RELACIONADOS AO USUARIO******

            .UseMySql(connectionString,m => m.MigrationsAssembly("QuickBuy.Repositorio")));
            //vai ser responsavel por abrir a conex�o com o banco de dados
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });


            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");                    
                   // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
                }
            });
        }
    }

}
