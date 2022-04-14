using EndlessJourney.Services.Data.Destinations;
using EndlessJourney.Web.ViewModels.Destinations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndlessJourney.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationsService destinationsService;

        public DestinationsController(
            IDestinationsService destinationsService)
        {
            this.destinationsService = destinationsService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            var viewModel = new DestinationListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = await this.destinationsService.GetCountAsync(),
                Destinations = await this.destinationsService.GetAllAsync<DestinationViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }
    }
}
