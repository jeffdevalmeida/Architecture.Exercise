using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Internal;
using BTG.Task.Application;
using BTG.Task.Application.Repository;
using BTG.Task.Infrastructure.DataAccess.DynamoDB.Repository;
using BTG.Task.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(RegionEndpoint.USEast2));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskApplication, TaskApplication>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings.KeyName));
            return services;
        }
    }
}
