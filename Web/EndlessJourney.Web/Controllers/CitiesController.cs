﻿namespace EndlessJourney.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EndlessJourney.Services.Data.Cities;
    using EndlessJourney.Web.ViewModels.Cities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants.RolesNamesConstants;

    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;

        public CitiesController(
            ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new CreateCityInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCityInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.citiesService.CreateAsync(inputModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(inputModel);
            }

            this.TempData["Message"] = "City added successfully.";

            return this.RedirectToAction(nameof(DestinationsController.All), "Destinations");
        }
    }
}
