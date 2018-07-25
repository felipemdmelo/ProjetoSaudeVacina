using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using ProjetoSaudeVacina.Domain.Services;
using ProjetoSaudeVacina.Infra.Data.Context;
using ProjetoSaudeVacina.Infra.Data.Repositories;
using AutoMapper;
using ProjetoSaudeVacina.API.Models.PostoSaude.Out;
using ProjetoSaudeVacina.API.Models.PostoSaude.In;
using ProjetoSaudeVacina.API.Models.Vacina.Out;
using ProjetoSaudeVacina.API.Models.Vacina.In;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.Out;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In;
using ProjetoSaudeVacina.API.Models.Endereco.In;
using ProjetoSaudeVacina.API.Models.Endereco.Out;
using ProjetoSaudeVacina.API.Models.Cidadao.Out;
using ProjetoSaudeVacina.API.Models.Cidadao.In;
using ProjetoSaudeVacina.API.Models.TecnicoEnfermagem.Out;
using ProjetoSaudeVacina.API.Models.TecnicoEnfermagem.In;

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
            ConfigureAutoMapper();

            services.AddDbContext<ProjetoSaudeVacinaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProjetoSaudeVacinaContext"));
            });

            // Injeções de dependência..
            // Repositories..
            services.AddTransient<ICidadaoRepository, CidadaoRepository>();
            services.AddTransient<IPostoSaudeRepository, PostoSaudeRepository>();
            services.AddTransient<ITecnicoEnfermagemRepository, TecnicoEnfermagemRepository>();
            services.AddTransient<IVacinaRepository, VacinaRepository>();
            services.AddTransient<IVacinaEstoqueLancamentoRepository, VacinaEstoqueLancamentoRepository>();

            // Services..
            services.AddTransient<ICidadaoService, CidadaoService>();
            services.AddTransient<IPostoSaudeService, PostoSaudeService>();
            services.AddTransient<ITecnicoEnfermagemService, TecnicoEnfermagemService>();
            services.AddTransient<IVacinaService, VacinaService>();
            services.AddTransient<IVacinaEstoqueLancamentoService, VacinaEstoqueLancamentoService>();
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

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(x =>
            {
                // Mapeamentos da entidade Cidadao..
                x.CreateMap<Cidadao, CidadaoGetOutViewModel>();
                x.CreateMap<CidadaoPostInViewModel, Cidadao>();
                x.CreateMap<CidadaoPutInViewModel, Cidadao>();

                // Mapeamentos da entidade Endereco..
                x.CreateMap<Endereco, EnderecoGetOutViewModel>();
                x.CreateMap<EnderecoPostInViewModel, Endereco>();
                x.CreateMap<EnderecoPutInViewModel, Endereco>();

                // Mapeamentos da entidade PostoSaude..
                x.CreateMap<PostoSaude, PostoSaudeGetOutViewModel>();
                x.CreateMap<PostoSaudePostInViewModel, PostoSaude>();
                x.CreateMap<PostoSaudePutInViewModel, PostoSaude>();

                // Mapeamentos da entidade TecnicoEnfermagem..
                x.CreateMap<TecnicoEnfermagem, TecnicoEnfermagemGetOutViewModel>();
                x.CreateMap<TecnicoEnfermagemPostInViewModel, TecnicoEnfermagem>();
                x.CreateMap<TecnicoEnfermagemPutInViewModel, TecnicoEnfermagem>();

                // Mapeamentos da entidade Vacina..
                x.CreateMap<Vacina, VacinaGetOutViewModel>();
                x.CreateMap<VacinaPostInViewModel, Vacina>();
                x.CreateMap<VacinaPutInViewModel, Vacina>();

                // Mapeamentos da entidade VacinaEstoqueLancamento..
                x.CreateMap<VacinaEstoqueLancamento, VacinaEstoqueLancamentoGetOutViewModel>();
                x.CreateMap<VacinaEstoqueLancamentoAbastecimentoPostInViewModel, VacinaEstoqueLancamento>();
                x.CreateMap<VacinaEstoqueLancamentoAplicacaoPostInViewModel, VacinaEstoqueLancamento>();
            });
        }
    }
}
