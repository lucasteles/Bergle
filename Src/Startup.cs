using static System.Text.Json.Serialization.ReferenceHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Bergle.Data;
using Microsoft.EntityFrameworkCore;

namespace Bergle
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Src", Version = "v1" });
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<BergleContext>(options => { options
                .UseNpgsql(Configuration.GetConnectionString("Connection"))
                .UseSnakeCaseNamingConvention();
            });
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            BergleContext context
        ) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Src v1"));

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                DbSeeder.AdicionarLivros(context);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
