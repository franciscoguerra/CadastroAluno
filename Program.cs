
using CadastroAluno.Context;
using CadastroAluno.Controller;
using CadastroAluno.Models;
using CadastroAluno.Services;
using CadastroAluno.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CadastroAluno
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen(
                options =>
                {
                    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }
                );

            builder.Services.AddDbContext<CadastroAlunoDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddScoped<IServicesAluno, AlunoService>();
            builder.Services.AddScoped<IServiceCurso, CursoService>();
            builder.Services.AddScoped<IGeneric, GenericServices>();
            builder.Services.AddLogging();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}