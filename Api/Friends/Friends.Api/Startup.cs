using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Friends.Persistence;
using Friends.Common.Models;
using Friends.Application.Users;
using System.Threading.Tasks;
using Friends.Api.Middlewares;
using Friends.Application.Extentsions;
using Friends.Persistence.Extentsions;
using Friends.Api.Extensions;

namespace Friends.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var connectionStrings = Configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();

            services.AddScoped(_ => new ApplicationDbContext(connectionStrings.DefaultConnection));
            services.AddIdentity();
            services.AddJwtAuthentication(appSettings.Jwt);

            services.AddCors(o => o.AddPolicy("CorsPolicy",
                bullder =>
                {
                    bullder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
                }));

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));

            services.AddSingleton(Configuration);
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));

            services.RegisterRepositories();
            services.RegisterUnitOfWorks();
            services.RegisterServices();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Person Dictionary Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseGlobalExceptionHandler();

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Person Dictionary Api V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => Task.Run(() => context.Response.Redirect("/swagger/index.html")));
            });
        }
    }
}
