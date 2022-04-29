namespace EndlessJourney.Services.Data.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Destinations;
    using Microsoft.EntityFrameworkCore;

    using static EndlessJourney.Common.GlobalConstants.Destination;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(
            IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
        }

        public async Task CreateAsync(CreateDestinationInputModel destinationModel)
        {
            var isExist = this.destinationsRepository
                .AllAsNoTracking()
                .Any(x => x.StartPointId == destinationModel.StartPointId && x.EndPointId == destinationModel.EndPointId);

            if (isExist)
            {
                throw new Exception(DestinationAlreadyExist);
            }

            var destination = new Destination
            {
                Name = destinationModel.Name,
                Description = destinationModel.Description,
                StartPointId = destinationModel.StartPointId,
                EndPointId = destinationModel.EndPointId,
            };

            await this.destinationsRepository.AddAsync(destination);
            await this.destinationsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.destinationsRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        => await this.destinationsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<TModel>()
                .ToListAsync();

        public DestinationQueryServiceModel All(
            string endPoint = null,
            string searchTerm = null,
            DestinationSorting sorting = DestinationSorting.DateCreated,
            int currentPage = 1,
            int destinationsPerPage = int.MaxValue)
        {
            var destinationsQuery = this.destinationsRepository
                .AllAsNoTracking();

            if (!string.IsNullOrWhiteSpace(endPoint))
            {
                destinationsQuery = destinationsQuery.Where(c => c.EndPoint.Name == endPoint);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                destinationsQuery = destinationsQuery.Where(c =>
                    (c.EndPoint.Name + " " + c.StartPoint.Name).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            destinationsQuery = sorting switch
            {
                DestinationSorting.StartPoint => destinationsQuery.OrderByDescending(d => d.StartPoint),
                DestinationSorting.EndPoint => destinationsQuery.OrderBy(d => d.StartPoint).ThenBy(d => d.EndPoint),
                DestinationSorting.DateCreated or _ => destinationsQuery.OrderByDescending(d => d.Id),
            };

            var totalDestinations = destinationsQuery.Count();

            var destinations = this.GetDestinations(destinationsQuery
                .Skip((currentPage - 1) * destinationsPerPage)
                .Take(destinationsPerPage));

            return new DestinationQueryServiceModel
            {
                TotalDestinations = totalDestinations,
                CurrentPage = currentPage,
                DestinationsPerPage = destinationsPerPage,
                Destinations = destinations,
            };
        }

        public IEnumerable<string> AllEndPoints()
          => this.destinationsRepository
              .AllAsNoTracking()
              .Select(c => c.EndPoint.Name)
              .Distinct()
              .OrderBy(br => br)
              .ToList();

        public async Task<int> GetCountAsync()
            => await this.destinationsRepository
                .AllAsNoTracking()
                .CountAsync();

        private IEnumerable<DestinationViewModel> GetDestinations(IQueryable<Destination> destinationQuery)
            => destinationQuery
                .To<DestinationViewModel>()
                .ToList();
    }
}
