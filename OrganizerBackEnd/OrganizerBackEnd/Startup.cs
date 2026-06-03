using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Profiles;
using OrganizerBackEnd.Services;

namespace OrganizerBackEnd;

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
        services.AddDbContextPool<IOrganizerContext, OrganizerContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("OrganizerConnect")));

        services.AddAutoMapper(cfg => { }, typeof(ListaProfile), typeof(TarefaProfile));
        services.AddScoped<IService<Lista>, ListaService>();
        services.AddScoped<IService<Tarefa>, TarefasService>();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrganizerBackEnd", Version = "v1" });
        });
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

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}