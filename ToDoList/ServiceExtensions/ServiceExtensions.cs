using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Context;
using Repositories.Contract;
using Services;
using Services.Contract;

namespace ToDoList.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 23)),
            b => b.MigrationsAssembly("ToDoList")));
            
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoService, ToDoServices>();
        }

    }
}
