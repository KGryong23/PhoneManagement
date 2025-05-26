using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneManagement.Data;
using PhoneManagement.Repositories;
using PhoneManagement.Services;

namespace PhoneManagement
{
    /// <summary>
    /// Cấu hình Dependency Injection
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            return services;
        }
    }
}
