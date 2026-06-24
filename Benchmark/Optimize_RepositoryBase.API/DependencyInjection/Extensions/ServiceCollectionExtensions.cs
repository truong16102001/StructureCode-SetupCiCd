using Microsoft.EntityFrameworkCore;
using Optimize_RepositoryBase.API.Abstractions;
using Optimize_RepositoryBase.API.Infrastructure;
using Optimize_RepositoryBase.API.Repositories;

namespace Optimize_RepositoryBase.API.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    options => options.MigrationsAssembly("Optimize_RepositoryBase.API"))
                       .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            );
        }

        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));

            services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            services.AddTransient(typeof(IRepositoryBaseGood<,>), typeof(RepositoryBaseGood<,>));

            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentServiceGood, StudentServiceGood>();
        }
    }
}
