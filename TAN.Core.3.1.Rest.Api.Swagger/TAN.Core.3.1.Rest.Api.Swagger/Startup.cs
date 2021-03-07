using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TAN.Core._3._1.Rest.Api.Swagger
{
    public class Startup<C> where C : class, IStartupCustom, new()
    {
        public IConfiguration Configuration { get; }

        public C Config { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Config = new C();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Config.AddSwaggerConfigure(services);

            services.AddControllers();
            services.AddApiVersioning();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Contact V2");
                c.RoutePrefix = "swagger";

                c.InjectStylesheet("/css/custom_swagger.css");
            });
        }
    }
}
