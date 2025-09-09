// Services/ServiceExtensions.cs
using Microsoft.Extensions.DependencyInjection;
using Speccon.Learnership.FrontEnd.Services.PracticalService;

namespace Speccon.Learnership.FrontEnd.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPracticalServices(this IServiceCollection services)
        {
            services.AddScoped<IPracticalAssignmentService, PracticalAssignmentService>();
            return services;
        }
    }
}