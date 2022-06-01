using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualAcademy.Persistence.Identity.Models;

namespace VirtualAcademy.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("VirtualAcademyConnectionString")));
            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
