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
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/45344819_1598993460247215_520391431722893312_o.jpg",
                    Extension = "jpg",
                },
                new Image
                {
                    TripId = null,
                    PathName = "/images/trips/45355403_1601031563376738_456487206031196160.jpg",
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
