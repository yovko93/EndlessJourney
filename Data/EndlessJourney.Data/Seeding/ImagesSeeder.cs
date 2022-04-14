namespace EndlessJourney.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EndlessJourney.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var imagesList = new List<Image>()
            {
                new Image
                {
                    ShipId = 1,
                    PathName = "/images/CaribbeanPrincess.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 2,
                    PathName = "/images/SunPrincess.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 3,
                    PathName = "/images/Fantasy.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 4,
                    PathName = "/images/Columbus2.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 5,
                    PathName = "/images/QueenMary2.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-148543868-612x612.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-509846884-612x612.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-636665220-612x612.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-1192581562-612x612.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-1187480763-612x612.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/istockphoto-1170809635-612x612.jpg",
                    Extension = "jpg",
                },
            };

            foreach (Image image in imagesList)
            {
                var dbImage = await dbContext.Images
                    .FirstOrDefaultAsync(x => x.PathName == image.PathName);

                if (dbImage == null)
                {
                    await dbContext.Images.AddAsync(image);
                }
            }
        }
    }
}
