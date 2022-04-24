namespace EndlessJourney.Web.Controllers
{
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Ships;
    using EndlessJourney.Web.ViewModels.Ships;
    using Microsoft.AspNetCore.Mvc;

    public class ShipsController : Controller
    {
        private readonly IShipsService shipsService;

        public ShipsController(IShipsService shipsService)
        {
            this.shipsService = shipsService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = new ShipsListViewModel
            {
                Ships = await this.shipsService.GetAllAsync<ShipViewModel>(),
                Count = await this.shipsService.GetCountAsync(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(int id)
        {
            var ship = await this.shipsService
                .GetByIdAsync<SingleShipViewModel>(id);

            if (ship == null)
            {
                return this.NotFound();
            }

            return this.View(ship);
        }
    }
}
