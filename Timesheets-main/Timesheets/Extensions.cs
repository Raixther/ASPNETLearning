using Microsoft.Extensions.DependencyInjection;
using Timesheets.DAL.Repository.DataBase;

namespace Timesheets
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlRepositories(this IServiceCollection container)
        {
            container.AddSingleton<Context>();

            return container;
        }
    }
}