using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MKS.IoC
{

    /// <summary>
    /// Extension class for adding database context.
    /// </summary>
    public static class AddDatabaseContextExtension
    {

        /// <summary>
        /// Extension method for configuring database context.
        /// </summary>
        /// <param name="serviceCollection">Collection of services for registering custom services.</param>
        /// <param name="connectionString">Connection string to database.</param>
        public static void AddDatabaseContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<YNote.Infrastructure.YNoteDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}