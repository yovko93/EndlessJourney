namespace EndlessJourney.Services.Data.Bookings
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Common.Repositories;
    using EndlessJourney.Data.Models;
    using EndlessJourney.Services.Mapping;
    using EndlessJourney.Web.ViewModels.Bookings;
    using Microsoft.EntityFrameworkCore;

    public class BookingsService : IBookingsService
    {
        private readonly IDeletableEntityRepository<Booking> bookingsRepository;
        private readonly IDeletableEntityRepository<UserTrip> userTripsRepository;
        private readonly IDeletableEntityRepository<Trip> tripsRepository;

        public BookingsService(
            IDeletableEntityRepository<Booking> bookingsRepository,
            IDeletableEntityRepository<UserTrip> userTripsRepository,
            IDeletableEntityRepository<Trip> tripsRepository)
        {
            this.bookingsRepository = bookingsRepository;
            this.userTripsRepository = userTripsRepository;
            this.tripsRepository = tripsRepository;
        }

        public async Task BookAsync(BookingInputModel bookingModel)
        {
            var booking = new Booking
            {
                Adult = bookingModel.Adult,
                Children = bookingModel.Children,
                CustomerId = bookingModel.UserId,
                TripId = bookingModel.TripId,
            };

            await this.bookingsRepository.AddAsync(booking);
            await this.bookingsRepository.SaveChangesAsync();

            var userTrip = new UserTrip
            {
                UserId = booking.CustomerId,
                TripId = booking.TripId,
            };

            await this.userTripsRepository.AddAsync(userTrip);
            await this.userTripsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByUserIdAsync<TModel>(string userId, int page, int itemsPerPage = 6)
            => await this.tripsRepository
                .AllAsNoTracking()
                .Where(x => x.Users.Any(x => x.UserId == userId))
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<TModel>()
                .ToListAsync();

        public async Task<int> GetCountByUserIdAsync(string userId)
            => await this.userTripsRepository
                .AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .CountAsync();
    }
}
