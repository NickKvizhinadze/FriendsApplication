using Microsoft.Extensions.DependencyInjection;
using Friends.Application.Members;
using Friends.Application.Members.Abstractions;

namespace Friends.Application.Extentsions
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMemberService), typeof(MemberService));
        }
    }
}
