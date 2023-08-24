using AutoMapper;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Infra.SqlServer;
using Infraestrutura.MapeadoresAutoMapper;
using Infraestrutura.Repositorios;
using Servicos.Servicos;
using WebApi.Trabalhadores;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

           

            var configuracao = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoParaModeloProfile());
                cfg.AddProfile(new EntidadeParaDtoProfile());
                cfg.AddProfile(new ModeloParaEntidadeProfile());
            });
            IMapper mapper = configuracao.CreateMapper();
            builder.Services.AddSingleton(mapper);


            builder.Services.AdicionarSqlServer(config);
            builder.Services.AddTransient<IPainelMicroondasRepositorio, PainelMicroondasRepositorio>();
            builder.Services.AddTransient(typeof(IRepositorio<>), typeof(BaseRepositorio<>));
            builder.Services.AddTransient<IProgramasAquecimentoRepositorio, ProgramasAquecimentoRepositorio>();
            builder.Services.AddTransient<IAquecimentoServico, AquecimentoServico>();


               var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}