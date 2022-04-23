namespace EndlessJourney.Services.Data.Bookings
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Web.ViewModels.Bookings;

    public interface IBookingsService
    {
        Task BookAsync(BookingInputModel bookingModel);

        Task<IEnumerable<TModel>> GetAllByUserIdAsync<TModel>(string userId);

        Task<int> GetCountByUserIdAsync(string userId);
    }
}
