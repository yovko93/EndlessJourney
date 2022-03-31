namespace EndlessJourney.Web.Areas.Administration.Controllers
{
    using EndlessJourney.Common;
    using EndlessJourney.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static EndlessJourney.Common.GlobalConstants.RolesNamesConstants;

    [Authorize(Roles = AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
