using Microsoft.Extensions.DependencyInjection;
using Friends.Persistence.Members;
using Friends.Application.Members.Abstractions;

namespace Friends.Persistence.Extentsions
{
    public static class DataDependencyInjectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMembersRepository), typeof(MembersRepository));
            services.AddScoped(typeof(IMemberFriendsRepository), typeof(MemberFriendsRepository));
        }

        public static void RegisterUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMembersUow), typeof(MembersUow));
        }
    }
}
