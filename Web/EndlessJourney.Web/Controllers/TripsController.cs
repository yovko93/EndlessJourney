namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Trips;
    using EndlessJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants.RolesNamesConstants;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;
        private readonly IWebHostEnvironment environment;

        public TripsController(
            ITripsService tripsService,
            IWebHostEnvironment environment)
        {
            this.tripsService = tripsService;
            this.environment = environment;
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
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTripInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // TODO remove
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.tripsService.CreateAsync(input, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Trip added successfully.";

            // TODO: Redirect to recipe info page
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var inputModel = this.tripsService
                .GetByIdAsync<EditTripInputModel>(id);

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, EditTripInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.tripsService.UpdateAsync(id, input);
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
