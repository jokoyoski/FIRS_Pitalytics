using System;
using System.Data.Common;
using System.Data.Entity;

namespace Pitalytics.Repositories.DataAccess
{
    public partial class PitalyticsEntities
    {

        public PitalyticsEntities(DbConnection dbConnection, bool contextOwnsConnection)
             : base(dbConnection, contextOwnsConnection)
        {
        }
    }
}
