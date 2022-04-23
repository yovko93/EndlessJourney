namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Cities;
    using EndlessJourney.Services.Data.Destinations;
    using EndlessJourney.Web.ViewModels.Destinations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants.RolesNamesConstants;

    public class DestinationsController : Controller
    {
        private readonly IDestinationsService destinationsService;
        private readonly ICitiesService citiesService;

        public DestinationsController(
            IDestinationsService destinationsService,
            ICitiesService citiesService)
        {
            this.destinationsService = destinationsService;
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = new DestinationsListViewModel
            {
                Destinations = await this.destinationsService.GetAllAsync<DestinationViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new CreateDestinationInputModel();
            viewModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateDestinationInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            try
            {
                await this.destinationsService.CreateAsync(inputModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                this.TempData["Message"] = ex.Message;

                return this.RedirectToAction(nameof(DestinationsController.All), "Destinations");
            }

            this.TempData["Message"] = "Destination added successfully.";

            return this.RedirectToAction(nameof(DestinationsController.All), "Destinations");
        }
    }
}
