using FinalProject.Application.Interfaces.Contexts;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.Identity;
using FinalProject.Domain.Models;
using FinalProject.Persistance.Contexts;
using FinalProject.Persistance.Repositories.MongoRepositories.ArchivedShopListRepositories;
using FinalProject.Persistance.Services.CategoryServices;
using FinalProject.Persistance.Services.ProductServices;
using FinalProject.Persistance.Services.ShopListServices;
using FinalProject.Persistance.Services.UserServices;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.CategoryRepositories;
using FinalProject.Persistence.Repositories.Common;
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
            if (enviroment == "Test")
            {
                services.AddDbContext<MsSqlDbContext>(options =>
               options.UseInMemoryDatabase("TestDatabaseMs"), ServiceLifetime.Singleton);
            }
            else
            {
                services.AddDbContext<MsSqlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection")), ServiceLifetime.Singleton);
            }

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<MsSqlDbContext>();

            services.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetConnectionString("Redis"));


            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDb"));
            services.AddScoped<IArchiveShopListQueryRepository, ArchiveShopListQueryRepository>();
            services.AddScoped<IArchiveShopListCommandRepository, ArchiveShopListCommandRepository>();

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<IShopListCommandRepository, ShopListCommandRepository>();
            services.AddScoped<IShopListQueryRepository, ShopListQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

            services.AddScoped<IBaseQueryRepository<Category>, BaseQueryRepository<Category>>();
            services.AddScoped<IBaseCommandRepository<Category>, BaseCommandRepository<Category>>();
            services.AddScoped<IBaseQueryRepository<Product>, BaseQueryRepository<Product>>();
            services.AddScoped<IBaseCommandRepository<Product>, BaseCommandRepository<Product>>();
            services.AddScoped<IBaseQueryRepository<ShopList>, BaseQueryRepository<ShopList>>();
            services.AddScoped<IBaseCommandRepository<ShopList>, BaseCommandRepository<ShopList>>();

            services.AddScoped<ICategoryQueryService, CategoryQueryService>();
            services.AddScoped<ICategoryCommandService, CategoryCommandService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IShopListQueryService, ShopListQueryService>();
            services.AddScoped<IShopListCommandService, ShopListCommandService>();
            services.AddScoped<IUserService, UserService>();


        }
    }
}
