using DFDS.Challange.Customer.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DFDS.Challange.Customer.Api.Extensions
{
    public static class EfTemplateContextExtensions
    {
        public static IServiceCollection AddEfTemplateContext(this IServiceCollection collection)
        {
            var configuration = collection.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetSection("ConnectionString").Get<string>();
            collection.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(connectionString));

            return collection;
        }
    }

}
