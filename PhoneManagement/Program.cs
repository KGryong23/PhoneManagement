using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory) // Sử dụng đường dẫn cơ bản từ AppDomain
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Sử dụng đúng namespace
               .Build();

            services.AddServices(configuration);
            services.AddScoped<FormPhone>();
            services.AddScoped<FormPhoneInsertOrUpdate>();
            services.AddScoped<FormPhoneDetail>();  
            //services.AddScoped<FormBrand>();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<FormPhone>();
                Application.Run(form);
            }
        }
    }
}