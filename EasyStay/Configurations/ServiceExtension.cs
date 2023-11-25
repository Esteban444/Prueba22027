using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Domain.Services;
using EasyStay.Infraestructure.DataAcces;
using Microsoft.EntityFrameworkCore;

namespace EasyStay.WebApi.Configurations
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration Configuracion)
        {
            services.AddDbContext<EasyStayDbContex>(options => options.UseSqlServer(Configuracion.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers(option =>
            {


            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IRepositoryCompany, CompanyRepository>();



            services.AddScoped<JwtHandler>();
            services.AddScoped<IAccountService, AccountService>();
            

            return services;
        }

    }
}
