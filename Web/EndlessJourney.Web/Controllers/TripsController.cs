namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using EndlessJourney.Services.Data.Destinations;
    using EndlessJourney.Services.Data.Ships;
    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants.RolesNamesConstants;

    public class TripsController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ITripsService tripsService;
        private readonly IShipsService shipsService;
        private readonly IDestinationsService destinationsService;

        public TripsController(
            IWebHostEnvironment environment,
            ITripsService tripsService,
            IShipsService shipsService,
            IDestinationsService destinationsService)
        {
            this.environment = environment;
            this.tripsService = tripsService;
            this.shipsService = shipsService;
            this.destinationsService = destinationsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            var viewModel = new TripsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                TripsCount = await this.tripsService.GetCountAsync(),
                Trips = await this.tripsService.GetAllAsync<TripViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(string id)
        {
            var trip = await this.tripsService
                .GetByIdAsync<SingleTripViewModel>(id);

            return this.View(trip);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new CreateTripInputModel();
            viewModel.Destinations = this.destinationsService.GetAllAsKeyValuePairs();
            viewModel.Ships = this.shipsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTripInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Destinations = this.destinationsService.GetAllAsKeyValuePairs();
                inputModel.Ships = this.shipsService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            // TODO remove
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.tripsService.CreateAsync(inputModel, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                inputModel.Destinations = this.destinationsService.GetAllAsKeyValuePairs();
                inputModel.Ships = this.shipsService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            this.TempData["Message"] = "Trip added successfully.";

            // TODO: Redirect to recipe info page
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var inputModel = this.tripsService.GetByIdAsync<EditTripInputModel>(id).Result;

            inputModel.Destinations = this.destinationsService.GetAllAsKeyValuePairs();
            inputModel.Ships = this.shipsService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, EditTripInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Destinations = this.destinationsService.GetAllAsKeyValuePairs();
                inputModel.Ships = this.shipsService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            await this.tripsService.UpdateAsync(id, inputModel);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.tripsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
