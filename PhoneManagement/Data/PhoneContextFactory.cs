using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PhoneManagement.Data
{
    /// <summary>
    /// Factory để tạo PhoneContext tại design-time (cho lệnh Add-Migration)
    /// </summary>
    public class PhoneContextFactory : IDesignTimeDbContextFactory<PhoneContext>
    {
        public PhoneContext CreateDbContext(string[] args)
        {
            // Đọc cấu hình từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PhoneContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new PhoneContext(optionsBuilder.Options);
        }
    }
}
