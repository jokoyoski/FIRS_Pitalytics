using System.Data.Entity;

namespace Pitalytics.Interfaces
{
   public interface IDbContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}