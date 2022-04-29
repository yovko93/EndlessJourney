namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Cities;
    using EndlessJourney.Services.Data.Destinations;
    using EndlessJourney.Web.ViewModels.Destinations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants;
    using static EndlessJourney.Common.GlobalConstants.Destination;
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

        public async Task<IActionResult> All([FromQuery] DestinationsListViewModel query)
        {
            //var viewModel = new DestinationsListViewModel
            //{
            //    Destinations = await this.destinationsService.GetAllAsync<DestinationViewModel>(),
            //};

            //return this.View(viewModel);

            var queryResult = this.destinationsService.All(
                query.EndPoint,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                DestinationsListViewModel.DestinationsPerPage);

            var destinationEndPoints = this.destinationsService.AllEndPoints();

            query.EndPoints = destinationEndPoints;

            query.TotalDestinations = queryResult.TotalDestinations;
            query.Destinations = queryResult.Destinations;

            return this.View(query);
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

                this.TempData[Message] = ex.Message;

                inputModel.Cities = this.citiesService.GetAllAsKeyValuePairs();

                return this.View(inputModel);
            }

            this.TempData[Message] = DestinationAdded;

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
