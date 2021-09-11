using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Filters;
using WebAPI.Infrastructure;

namespace WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            services.AddHealthChecks()
                    .AddCheck<ExampleHealthCheck>("example_health_check");

            services.AddControllers(config =>
            {
                config.Filters.Add<MyResourceFilter>();

                config.Filters.Add<MyActionLogFilter>();      // <------ primeiro filtro enfileirado                
                config.Filters.Add<MyActionValidationlFilter>();  // <------ segundo filtro enfileirado
                
                config.Filters.Add<MyExceptionFilter>();

                config.Filters.Add<MyResultFilter>();
            });

            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<IRepository, Repository>();

            services.AddCommandsAndHandlers();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<RequestCultureMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Ola! Seja bemvindo!");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/api/health");

                endpoints.MapGet("/api/login", async context =>
                {
                    await context.Response.WriteAsync("Login realizado!");
                });
            });            
        }
    }
}
