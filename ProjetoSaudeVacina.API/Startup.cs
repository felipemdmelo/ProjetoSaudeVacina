using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;
using ProjetoSaudeVacina.Infra.Data.Repositories;

namespace ProjetoSaudeVacina.API
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
            services.AddMvc();

            services.AddDbContext<ProjetoSaudeVacinaContext>(
            options => options.UseSqlServer(Configuration.GetConnectionString("ProjetoSaudeVacinaContext")));

            // Injeções de dependência..
            services.AddTransient<IPostoSaudeRepository, PostoSaudeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
