using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;
using System;

namespace OrganizerBackEnd
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
      services.AddDbContext<IOrganizerContext, OrganizerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrganizerConnect")));

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrganizerBackEnd", Version = "v1" });
      });
      InjetarDependenciasDeServico(services);
    }

    private static void InjetarDependenciasDeServico(IServiceCollection services)
    {
      services.AddScoped<IServices<Lista>, ListaServices>();
      services.AddScoped<IServices<Tarefa>, TarefasServices>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrganizerBackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(c =>
                    c
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
