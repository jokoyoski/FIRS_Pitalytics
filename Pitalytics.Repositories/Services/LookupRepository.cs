using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitalytics.Interfaces;
using Pitalytics.Repositories.DataAccess;
using Pitalytics.Interfaces.ValueTypes;
using Pitalytics.Repositories.Queries;

namespace Pitalytics.Repositories.Services
{
    public class LookupRepository : ILookupRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LookupRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }




       

    }
}
