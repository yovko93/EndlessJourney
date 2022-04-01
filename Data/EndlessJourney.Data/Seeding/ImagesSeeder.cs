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
                    PathName = "/wwwroot/images/CaribbeanPrincess",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 2,
                    PathName = "/wwwroot/images/SunPrincess",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 3,
                    PathName = "/wwwroot/images/Fantasy",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 4,
                    PathName = "/wwwroot/images/Columbus2",
                    Extension = "jpg",
                },
                new Image
                {
                    ShipId = 5,
                    PathName = "/wwwroot/images/QueenMary2",
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
