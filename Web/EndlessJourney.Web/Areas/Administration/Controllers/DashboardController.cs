namespace EndlessJourney.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;

    using EndlessJourney.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Samsung", 25));
            dataPoints.Add(new DataPoint("Micromax", 13));
            dataPoints.Add(new DataPoint("Lenovo", 8));
            dataPoints.Add(new DataPoint("Intex", 7));
            dataPoints.Add(new DataPoint("Reliance", 6.8));
            dataPoints.Add(new DataPoint("Others", 40.2));

            this.ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return this.View();
        }
    }
}
