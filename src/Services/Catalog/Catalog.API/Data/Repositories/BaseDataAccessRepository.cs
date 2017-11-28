namespace IBM.Books.Catalog.API.Data.Repositories
{
    using IBM.Books.Catalog.API.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class to access to application persistent data
    /// </summary>
    public abstract class BaseDataAccessRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected readonly CatalogContext catalogContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogContext">database context</param>
        public BaseDataAccessRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
    }
}