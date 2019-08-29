using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity;

using Environment = AA.Infrastructure.Utility.Environment;
using Pitalytics.Interfaces;

using System.Data.Common;
using Pitalytics.Repositories.DataAccess;
using AA.Infrastructure.Interfaces;
using Pitalytics.Interfaces.ValueTypes;

namespace Pitalytics.Repositories.Factories
{

    public class DbContextFactory : IDbContextFactory
    {
        private readonly IEnvironment environment;

        public DbContextFactory(IEnvironment environment)
        {
            this.environment = environment ?? new Environment();
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">contextType</exception>
        /// <exception cref="ApplicationException">
        /// </exception>
        public DbContext GetDbContext()
        {
          

            DbContext dbContext = null;

            var userId = this.environment[EnvironmentValues.PitalyticId];
            var password = this.environment[EnvironmentValues.PitalyticPwd];
            var server = this.environment[EnvironmentValues.PitalyticSvr];
            var contextType = this.environment[EnvironmentValues.PitayticDb];

            if (string.IsNullOrEmpty(contextType))
            {
                throw new ApplicationException(string.Format("Database not specified"));
            }
            if (string.IsNullOrEmpty(server))
            {
                throw new ApplicationException(string.Format("Server not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException(string.Format("UserId not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException(string.Format("Password not specified in Environment file for database{0}",
                    contextType));
            }

            string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server,
                contextType, userId, password);

            var entities = new EntityConnectionStringBuilder
            {
                Metadata = @"res://*/DataAccess.Pitalytics.csdl|res://*/DataAccess.Pitalytics.ssdl|res://*/DataAccess.Pitalytics.msl",
                ProviderConnectionString = connString,
                Provider = "System.Data.SqlClient"
            };

            DbConnection dbConnection = new EntityConnection(entities.ConnectionString);
            dbContext = new PitalyticsEntities(dbConnection, true);


            return dbContext;
        }

       
    }

}