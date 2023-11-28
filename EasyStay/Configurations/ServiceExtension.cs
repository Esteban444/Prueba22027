using EasyStay.Contracts.Repositories;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Domain.Services;
using EasyStay.Infraestructure.DataAcces;
using EasyStay.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyStay.WebApi.Configurations
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EasyStayDbContex>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();



            services.AddScoped<TokenHandler>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IReservationService, ReservationService>();


            return services;
        }

    }
}
