using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Domain.Entities.Identity;
using FinalProject.Persistance.Services.CategoryServices;
using FinalProject.Persistance.Services.ProductServices;
using FinalProject.Persistance.Services.ShopListServices;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.CategoryRepositories;
using FinalProject.Persistence.Repositories.ProductRepositories;
using FinalProject.Persistence.Repositories.ShopListRepositories;
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

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<IShopListCommandRepository, ShopListCommandRepository>();
            services.AddScoped<IShopListQueryRepository, ShopListQueryRepository>();
            services.AddSingleton<IShopListCommandArchiveRepository, ShopListCommandArchiveRepository>();
            services.AddScoped<IShopListQueryArchiveRepository, ShopListQueryArchiveRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

            services.AddScoped<ICategoryQueryService, CategoryQueryService>();
            services.AddScoped<ICategoryCommandService, CategoryCommandService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IShopListQueryService, ShopListQueryService>();
            services.AddScoped<IShopListCommandService, ShopListCommandService>();


        }
    }
}
