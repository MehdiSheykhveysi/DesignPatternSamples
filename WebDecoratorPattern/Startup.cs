using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProxyPattern.Cashe;
using ProxyPattern.Cashe.CasheImpliments;
using ProxyPattern.Domain.Contract;
using ProxyPattern.Infrastructure.Data;
using ProxyPattern.Repository;

namespace WebDecoratorPattern
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services,IConfiguration configuration)
        {
            //services.AddMemoryCache();
            services.AddDistributedSqlServerCache(settings=> {
                settings.ConnectionString = "Data Source=My System IP Config ;Initial Catalog=DesignPatternDB;My user And Pass";
                settings.TableName = "DisDesignPatternCashe";
                settings.SchemaName = "dbo";
            });
            services.AddDbContext<DesignPatternContext>(options =>
            {
                options.UseSqlServer(configuration.GetValue<string>("DefaultConnection"));
            });
            services.AddScoped<PersonCasheProxy, PersonCasheProxy>();
            services.AddScoped<EFPersonRepository, EFPersonRepository>();
            services.AddScoped<ICasheAdapter, DisterbutedCacheAdapter>();

            services.AddTransient<IPersonRepository>(factory=> {
                bool useCashe = configuration.GetValue<bool>("UseCashe");
                if (useCashe)
                    return factory.GetService<PersonCasheProxy>();
                else
                    return factory.GetService<EFPersonRepository>();
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
