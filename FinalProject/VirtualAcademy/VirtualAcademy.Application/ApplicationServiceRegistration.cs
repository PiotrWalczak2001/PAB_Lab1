using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VirtualAcademy.Application.Contracts.Services;
using VirtualAcademy.Application.Features.Courses.Services;
using VirtualAcademy.Application.Features.Files.Services;

namespace VirtualAcademy.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ICourseService, CourseService>();

            return services;
        }
    }
}
