using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using ProjetoSaudeVacina.Domain.Services;
using ProjetoSaudeVacina.Infra.Data.Context;
using ProjetoSaudeVacina.Infra.Data.Repositories;
using ProjetoSaudeVacina.MVC.Models.Endereco.In;
using ProjetoSaudeVacina.MVC.Models.PostoSaude.In;
using ProjetoSaudeVacina.MVC.Models.Vacina.In;
using ProjetoSaudeVacina.MVC.Models.Vacina.Out;

namespace ProjetoSaudeVacina.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureAutoMapper();

            services.AddDbContext<ProjetoSaudeVacinaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Injeções de dependência..
            // Repositories..
            services.AddTransient<IVacinaRepository, VacinaRepository>();
            services.AddTransient<IPostoSaudeRepository, PostoSaudeRepository>();

            // Services..
            services.AddTransient<IVacinaService, VacinaService>();
            services.AddTransient<IPostoSaudeService, PostoSaudeService>();
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Vacina}/{action=Index}/{id?}");
            });
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(x =>
            {
                // Mapeamentos da entidade Vacina..
                x.CreateMap<VacinaPostInViewModel, Vacina>();
                x.CreateMap<VacinaPutInViewModel, Vacina>();

                // Mapeamentos da entidade PostoSaude..
                x.CreateMap<PostoSaudePostInViewModel, PostoSaude>();
                x.CreateMap<PostoSaudePutInViewModel, PostoSaude>();

                // Mapeamentos da entidade Endereco..
                x.CreateMap<EnderecoPostInViewModel, Endereco>();
                x.CreateMap<EnderecoPutInViewModel, Endereco>();
            });
        }
    }
}
