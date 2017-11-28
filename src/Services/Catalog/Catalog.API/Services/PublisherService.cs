namespace IBM.Books.Catalog.API.Services
{
    using IBM.Books.Catalog.API.BusinessModel;
    using IBM.Books.Catalog.API.Data.Repositories;
    using IBM.Books.Catalog.API.Infrastructure.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        public async Task<int?> GetIdAsync(string name)
        {
            int id = await publisherRepository.GetIdAsync(NormalizationHelper.NormalizePublisherName(name));
            if (id <= 0)
                return null;
            return id;
        }

        public async Task<int?> CreateAsync(PublisherModel publisher) =>
            await this.publisherRepository.CreateAsync(publisher);
    }
}