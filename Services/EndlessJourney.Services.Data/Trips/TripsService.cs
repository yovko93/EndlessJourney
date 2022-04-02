namespace EndlessJourney.Services.Data.Trips
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.EntityFrameworkCore;

    public class TripsService : ITripsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Trip> tripsRepository;

        public TripsService(
            IDeletableEntityRepository<Trip> tripsRepository)
        {
            this.tripsRepository = tripsRepository;
        }

        public async Task CreateAsync(CreateTripInputModel tripModel, string imagePath)
        {
            var trip = new Trip
            {
                StartDate = DateTime.Parse(tripModel.StartDate),
                EndDate = DateTime.Parse(tripModel.EndDate),
                Price = tripModel.Price,
                Discount = tripModel.Discount,
                DestinationId = tripModel.DestinationId,
                ShipId = tripModel.ShipId,
            };

            Directory.CreateDirectory($"{imagePath}/trips/");
            foreach (var image in tripModel.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };

                trip.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/trips/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
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
                // TODO:
            }

            this.tripsRepository.Delete(trip);
            await this.tripsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.tripsRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
            => await this.tripsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public int GetCount()
           => this.tripsRepository
               .AllAsNoTracking()
               .Count();

        public async Task<IEnumerable<TModel>> GetRandomAsync<TModel>(int count)
        {
            return await this.tripsRepository
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<TModel>()
                .ToListAsync();
        }

        public async Task UpdateAsync(string id, UpdateTripInputModel tripModel)
        {
            var trip = this.tripsRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            trip.StartDate = DateTime.Parse(tripModel.StartDate);
            trip.EndDate = DateTime.Parse(tripModel.EndDate);
            trip.Price = tripModel.Price;
            trip.Discount = tripModel.Discount;
            trip.DestinationId = tripModel.DestinationId;
            trip.ShipId = tripModel.ShipId;

            await this.tripsRepository.SaveChangesAsync();
        }
    }
}
