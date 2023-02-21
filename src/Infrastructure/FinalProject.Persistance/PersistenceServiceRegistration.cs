using FinalProject.Domain.Entities.Identity;
using FinalProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, string enviroment = "Development")
        {

            services.AddDbContext<MsSqlDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection")), ServiceLifetime.Singleton);


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<MsSqlDbContext>();


        }
    }
}
