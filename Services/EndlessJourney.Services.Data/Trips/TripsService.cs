namespace EndlessJourney.Services.Data.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.EntityFrameworkCore;

    using static EndlessJourney.Common.GlobalConstants.Ship;
    using static EndlessJourney.Common.GlobalConstants.Trip;

    public class TripsService : ITripsService
    {
        private readonly IDeletableEntityRepository<Trip> tripsRepository;

        public TripsService(
            IDeletableEntityRepository<Trip> tripsRepository)
        {
            this.tripsRepository = tripsRepository;
        }

        public async Task CreateAsync(CreateTripInputModel tripModel, IEnumerable<Image> images)
        {
            if (tripModel.StartDate > tripModel.EndDate)
            {
                throw new Exception(StartBeforeEndDate);
            }

            var isShipBusy = this.tripsRepository
                .AllAsNoTracking()
                .Any(x =>
                    x.StartDate.Date == tripModel.StartDate.Date
                        && x.ShipId == tripModel.ShipId);

            if (isShipBusy)
            {
                throw new Exception(ShipIsBusy);
            }

            var isExist = this.tripsRepository
                .AllAsNoTracking()
                .Any(x =>
                    x.DestinationId == tripModel.DestinationId
                    && x.ShipId == tripModel.ShipId
                    && x.StartDate.Date == tripModel.StartDate.Date);

            if (isExist)
            {
                throw new Exception(TripExistAlready);
            }

            var trip = new Trip
            {
                StartDate = tripModel.StartDate,
                EndDate = tripModel.EndDate,
                Price = tripModel.Price,
                Discount = tripModel.Discount,
                DestinationId = tripModel.DestinationId,
                ShipId = tripModel.ShipId,
            };

            foreach (var image in images)
            {
                trip.Images.Add(image);
            }

            await this.tripsRepository.AddAsync(trip);
            await this.tripsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var trip = await this.tripsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (trip == null)
            {
                throw new Exception(TripNotFound);
            }

            this.tripsRepository.Delete(trip);
            await this.tripsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllActiveAsync<TModel>(int page, int itemsPerPage = 6)
            => await this.tripsRepository
                .AllAsNoTracking()
                .Where(x => x.StartDate > DateTime.Now)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
            => await this.tripsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task<decimal> GetTripPriceAsync(string id)
            => await this.tripsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => x.Price)
                .FirstOrDefaultAsync();

        public async Task<int> GetCountAsync()
           => await this.tripsRepository
               .AllAsNoTracking()
               .CountAsync();

        public async Task<IEnumerable<TModel>> GetRandomAsync<TModel>(int count)
        {
            return await this.tripsRepository
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Where(x => x.StartDate > DateTime.Now)
                .Take(count)
                .To<TModel>()
                .ToListAsync();
        }

        public async Task UpdateAsync(string id, EditTripInputModel tripModel)
        {
            if (id == null)
            {
                throw new Exception(TripNotFound);
            }

            var trip = this.tripsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            trip.StartDate = tripModel.StartDate;
            trip.EndDate = tripModel.EndDate;
            trip.Price = tripModel.Price;
            trip.Discount = tripModel.Discount;
            trip.DestinationId = tripModel.DestinationId;
            trip.ShipId = tripModel.ShipId;

            await this.tripsRepository.SaveChangesAsync();
        }

        public IEnumerable<TModel> Latest<TModel>()
            => this.tripsRepository
                .All()
                .OrderByDescending(c => c.Id)
                .To<TModel>()
                .Take(3)
                .ToList();
    }
}
